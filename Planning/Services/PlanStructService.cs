using Planning.Data;
using Planning.Models;
using Planning.Services.Context;

namespace Planning.Services;

public class PlanStructService : IPlanStructService
{
    protected readonly IPlanningUnitOfWork _unitOfWork;
    protected readonly PlanningDbContext _dbContext;

    public PlanStructService(IPlanningUnitOfWork unitOfWork, PlanningDbContext dbContext)
    {
        _unitOfWork = unitOfWork;
        _dbContext = dbContext;
    }

    public List<PlanStruct> GetAll()
    {
        var data = _unitOfWork.PlanStructRepository.GetAll().ToList();
        return data;
    }

    public PlanStruct GetById(int id)
    {
        var data = _unitOfWork.PlanStructRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        return data;
    }

    public PlanStruct PostPlanStruct(PlanStruct planStruct)
    {
        _unitOfWork.PlanStructRepository.Insert(planStruct);
        _unitOfWork.SaveChanges();
        _unitOfWork.PlanStructRepository.Reload(planStruct);
        return planStruct;
    }

    public PlanStruct PutPlanStruct(PlanStruct planStruct)
    {
        _unitOfWork.PlanStructRepository.Update(planStruct);
        _unitOfWork.SaveChanges();
        _unitOfWork.PlanStructRepository.Reload(planStruct);
        return planStruct;
    }

    public PlanStruct DeletePlanStruct(int id)
    {
        var data = _unitOfWork.PlanStructRepository.GetAll().Where(p => p.Id == id).FirstOrDefault();
        if (data == null)
        {
            throw new Exception("Null value");
        }
        
        _unitOfWork.PlanStructRepository.Delete(data);
        _unitOfWork.SaveChanges();
        return data;
    }
}