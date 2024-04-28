using IronXL;
using Microsoft.AspNetCore.Mvc;
using Planning.Data;
using Planning.Models;
using Planning.Services.Context;

namespace Planning.Services;

public class FileGenService : IFileGenService
{
    protected readonly PlanningDbContext _dbContext;
    protected readonly IPlanningUnitOfWork _unitOfWork;

    public FileGenService(PlanningDbContext dbContext, IPlanningUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _unitOfWork = unitOfWork;
    }

    public async Task<FileContentResult> HandleSpredsheets(PreProcess preProcess)
    {
        List<PlanBase> data = new List<PlanBase>();
        List<List<PlanBase>> dataSet = new List<List<PlanBase>>();

        data = SetValuesToList(preProcess);

        foreach (int temp in preProcess.Templates) {
            PlanStruct planStruct = _unitOfWork.PlanStructRepository.GetAll().Where(p => p.Id == temp).FirstOrDefault();

            var vals = PrepareValues(data, planStruct.DayCount);
            dataSet.Add(vals);
        }

        FileContentResult fileContentResult = GenerateSpreadSheet(data, dataSet);
        return fileContentResult;
    }

    private List<PlanBase> SetValuesToList(PreProcess preProcess)
    {
        if (preProcess.File == null || preProcess.File.Length == 0)
            throw new Exception("File not selected");

        string fileExtension = Path.GetExtension(preProcess.File.FileName);
        if (fileExtension != ".xls" && fileExtension != ".xlsx")
            throw new Exception("Invalid file format");

        List<PlanBase> dataList = new List<PlanBase>();

        using (var stream = preProcess.File.OpenReadStream())
        {
            WorkBook workBook = WorkBook.Load(stream);
            WorkSheet workSheet = workBook.WorkSheets[0];

            for (int i = 2; i <= workSheet.Rows.Count(); i++)
            {
                PlanBase planBase = new PlanBase();
                planBase.Id = workSheet[$"A{i}"].IntValue;
                planBase.PO = workSheet[$"B{i}"].StringValue;
                planBase.Quantity = workSheet[$"C{i}"].DoubleValue;
                planBase.StartDate = ConvertStringToDateOnly(Convert.ToString(workSheet[$"D{i}"].Value));

                dataList.Add(planBase);
            }
        }

        return dataList;
    }

    private List<PlanBase> PrepareValues(List<PlanBase> dataList, int dayCount)
    {
        foreach (var data in dataList)
        {
            data.StartDate = AddBusinessDays(data.StartDate, dayCount);
        }

        return dataList;
    }

    private FileContentResult GenerateSpreadSheet(List<PlanBase> givenPlan, List<List<PlanBase>> plan)
    {
        if (plan == null || plan.Count == 0 || givenPlan == null || givenPlan.Count == 0)
            throw new Exception("No data to export.");

        var workbook = new WorkBook();
        var sheet = workbook.CreateWorkSheet("Sheet1");

        sheet["A1"].StringValue = "#";
        sheet["B1"].StringValue = "PO";
        sheet["C1"].StringValue = "Quantity";
        sheet["D1"].StringValue = "StartDate";

        for (int i = 2; i < plan.Count(); i++)
        {
            sheet[$"A{i}"].StringValue = Convert.ToString(givenPlan[i - 2].Id);
            sheet[$"B{i}"].StringValue = Convert.ToString(givenPlan[i - 2].PO);
            sheet[$"C{i}"].StringValue = Convert.ToString(givenPlan[i - 2].Quantity);
            sheet[$"D{i}"].StringValue = Convert.ToString(givenPlan[i - 2].StartDate);
        }

        for (int i = 0; i < plan.Count(); i++)
        {
            var worksheet = workbook.CreateWorkSheet($"Sheet{2 + i}");

            sheet["A1"].StringValue = "#";
            sheet["B1"].StringValue = "PO";
            sheet["C1"].StringValue = "Quantity";
            sheet["D1"].StringValue = "StartDate";

            for (int j = 2; j < plan.Count(); j++)
            {
                sheet[$"A{j}"].StringValue = Convert.ToString(givenPlan[j - 2].Id);
                sheet[$"B{j}"].StringValue = Convert.ToString(givenPlan[j - 2].PO);
                sheet[$"C{j}"].StringValue = Convert.ToString(givenPlan[j - 2].Quantity);
                sheet[$"D{j}"].StringValue = Convert.ToString(givenPlan[j - 2].StartDate);
            }
        }

        var fileName = $"Plan Updated on {DateTime.Now.ToString()}.xlsx";

        MemoryStream stream = new MemoryStream();
        stream = workbook.ToStream();
        byte[] excelFiles = stream.ToArray();
        
        return new FileContentResult(excelFiles, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            FileDownloadName = fileName
        };
    }

    private DateOnly AddBusinessDays(DateOnly date, int days)
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

    private DateOnly ConvertStringToDateOnly(string dateString)
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