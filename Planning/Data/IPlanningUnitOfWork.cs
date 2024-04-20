using Planning.Models;

namespace Planning.Data;

public interface IPlanningUnitOfWork
{
    // IBaseRepository<Department> DepartmentRepository { get; }
    
    User GetCurrentUser();
    Company GetCurrentCompany();
    void SaveChanges();
    void SaveChangesAsync();
}