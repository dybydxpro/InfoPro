using Planning.Models;

namespace Planning.Services.Context;

public interface IPlanStructService
{
    List<PlanStruct> GetAll();
    PlanStruct GetById(int id);
    PlanStruct PostPlanStruct(PlanStruct planStruct);
    PlanStruct PutPlanStruct(PlanStruct planStruct);
    PlanStruct DeletePlanStruct(int id);
}