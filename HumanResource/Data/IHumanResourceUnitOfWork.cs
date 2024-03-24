using HumanResource.Models;

namespace HumanResource.Data
{
    public interface IHumanResourceUnitOfWork
    {
        IBaseRepository<Department> DepartmentRepository { get; }
        IBaseRepository<Designation> DesignationRepository { get; }
        IBaseRepository<Employee> EmployeeRepository { get; }
    
        User GetCurrentUser();
        Company GetCurrentCompany();
        void SaveChanges();
        void SaveChangesAsync();
    }
}