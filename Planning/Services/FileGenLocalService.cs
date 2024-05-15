using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Planning.Data;
using Planning.Models;
using Planning.Services.Context;

namespace Planning.Services;

public class FileGenLocalService : IFileGenService
{
    protected readonly PlanningDbContext _dbContext;
    protected readonly IPlanningUnitOfWork _unitOfWork;

    public FileGenLocalService(PlanningDbContext dbContext, IPlanningUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _unitOfWork = unitOfWork;
    }

    public async Task<FileContentResult> HandleSpredsheets(PreProcess preProcess)
    {
        List<PlanBase> data = new List<PlanBase>();
        List<List<PlanBase>> dataSet = new List<List<PlanBase>>();
        List<PlanStruct> planStructs = new List<PlanStruct>();

        data = await SetValuesToList(preProcess);

        foreach (int temp in preProcess.Templates)
        {
            PlanStruct planStruct = _unitOfWork.PlanStructRepository.GetAll().Where(p => p.Id == temp).FirstOrDefault();
            planStructs.Add(planStruct);

            var vals = await this.PrepareValues(data, planStruct.DayCount);
            dataSet.Add(vals);
        }

        FileContentResult fileContentResult = await this.GenerateSpreadSheet(data, dataSet, planStructs);
        return fileContentResult;
    }

    protected async Task<List<PlanBase>> SetValuesToList(PreProcess preProcess)
    {
        if (preProcess.File == null || preProcess.File.Length == 0)
            throw new Exception("File not selected");
        
        string fileExtension = Path.GetExtension(preProcess.File.FileName);
        if (fileExtension != ".xls" && fileExtension != ".xlsx")
            throw new Exception("Invalid file format");

        List<PlanBase> dataList = new List<PlanBase>();

        using (var stream = preProcess.File.OpenReadStream())
        {
            IWorkbook workbook;
            if (fileExtension == ".xlsx")
                workbook = new XSSFWorkbook(stream);
            else
                workbook = new HSSFWorkbook(stream);
            ISheet  workSheet = workbook.GetSheetAt(0);

            for (int i = 1; i <= workSheet.LastRowNum; i++)
            {
                IRow row = workSheet.GetRow(i);
                if (row == null) continue; // Row is empty

                PlanBase planBase = new PlanBase();
                planBase.Id = (int)row.GetCell(0).NumericCellValue;
                planBase.PO = row.GetCell(1).StringCellValue;
                planBase.Quantity = row.GetCell(2).NumericCellValue;
                planBase.StartDate = await this.ConvertStringToDateOnly(Convert.ToString(row.GetCell(3).StringCellValue));

                dataList.Add(planBase);
            }
        }

        return dataList;
    }

    private async Task<List<PlanBase>> PrepareValues(List<PlanBase> dataList, int dayCount)
    {
        List<PlanBase> values = new List<PlanBase>();

        foreach (var singleData in dataList)
        {
            PlanBase val = new PlanBase();
            val.Id = singleData.Id;
            val.PO = singleData.PO;
            val.Quantity = singleData.Quantity;
            val.StartDate = await AddBusinessDays(singleData.StartDate, dayCount);

            values.Add(val);
        }

        return values;
    }

    private async Task<FileContentResult> GenerateSpreadSheet(List<PlanBase> givenPlan, List<List<PlanBase>> plan, List<PlanStruct> structs)
    {
        if (plan == null || plan.Count == 0 || givenPlan == null || givenPlan.Count == 0)
            throw new Exception("No data to export.");

        IWorkbook workbook = new XSSFWorkbook();
        ISheet sheet = workbook.CreateSheet("Given Plan");

        IRow headerRow = sheet.CreateRow(0);
        headerRow.CreateCell(0).SetCellValue("#");
        headerRow.CreateCell(1).SetCellValue("PO");
        headerRow.CreateCell(2).SetCellValue("Quantity");
        headerRow.CreateCell(3).SetCellValue("StartDate");

        for (int i = 0; i < givenPlan.Count; i++)
        {
            IRow row = sheet.CreateRow(i + 1);
            row.CreateCell(0).SetCellValue(givenPlan[i].Id);
            row.CreateCell(1).SetCellValue(givenPlan[i].PO);
            row.CreateCell(2).SetCellValue(givenPlan[i].Quantity);
            row.CreateCell(3).SetCellValue(givenPlan[i].StartDate.ToString());
        }

        for (int i = 0; i < plan.Count(); i++)
        {
            ISheet planSheet = workbook.CreateSheet($"Plan - {structs[i].Name}");
            IRow planHeaderRow = planSheet.CreateRow(0);
            planHeaderRow.CreateCell(0).SetCellValue("#");
            planHeaderRow.CreateCell(1).SetCellValue("PO");
            planHeaderRow.CreateCell(2).SetCellValue("Quantity");
            planHeaderRow.CreateCell(3).SetCellValue("StartDate");

            for (int j = 0; j < plan[i].Count(); j++)
            {
                IRow row = planSheet.CreateRow(j + 1);
                row.CreateCell(0).SetCellValue(plan[i][j].Id);
                row.CreateCell(1).SetCellValue(plan[i][j].PO);
                row.CreateCell(2).SetCellValue(plan[i][j].Quantity);
                row.CreateCell(3).SetCellValue(plan[i][j].StartDate.ToString());
            }
        }

        var fileName = $"Plan Updated on {DateTime.Now.ToString()}.xlsx";

        MemoryStream stream = new MemoryStream();
        workbook.Write(stream);
        byte[] excelFiles = stream.ToArray();

        return new FileContentResult(excelFiles, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            FileDownloadName = fileName
        };
    }

    private async Task<DateOnly> AddBusinessDays(DateOnly date, int days)
    {
        if (days == 0) return date;

        if (date.DayOfWeek == DayOfWeek.Saturday)
        {
            date = date.AddDays(days > 0 ? 2 : -1);
            days -= days > 0 ? 1 : -1;
        }
        else if (date.DayOfWeek == DayOfWeek.Sunday)
        {
            date = date.AddDays(days > 0 ? 1 : -2);
            days -= days > 0 ? 1 : -1;
        }

        if (days > 0)
        {
            date = date.AddDays(days / 5 * 7);
            int extraDays = days % 5;

            if ((int)date.DayOfWeek + extraDays > 5)
            {
                extraDays += 2;
            }

            return date.AddDays(extraDays);
        }
        else
        {
            date = date.AddDays((days / 5) * 7);
            int extraDays = days % 5;

            if ((int)date.DayOfWeek + extraDays < 0)
            {
                extraDays -= 2;
            }

            return date.AddDays(extraDays);
        }
    }

    private async Task<DateOnly> ConvertStringToDateOnly(string dateString)
    {
        string dateFormat = "dd/MM/yyyy";

        if (DateOnly.TryParseExact(dateString, dateFormat, null, System.Globalization.DateTimeStyles.None, out DateOnly result))
        {
            return result;
        }
        else
        {
            throw new ArgumentException("Invalid date string format");
        }
    }
}