using Planning.Models;

namespace Planning.Data;

public interface IPlanningUnitOfWork
{
    IBaseRepository<PlanStruct> PlanStructRepository { get; }
    
    User GetCurrentUser();
    Company GetCurrentCompany();
    void SaveChanges();
    void SaveChangesAsync();
}