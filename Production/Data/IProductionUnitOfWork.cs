using Production.Modals;

namespace Production.Data
{
    public interface IProductionUnitOfWork
    {
        IBaseRepository<Department> DepartmentRepository { get; }
        IBaseRepository<Designation> DesignationRepository { get; }
        IBaseRepository<Employee> EmployeeRepository { get; }
        IBaseRepository<ProductionFloor> ProductionFloorRepository { get; }
        IBaseRepository<FlowWorker> FlowWorkerRepository { get; }
        IBaseRepository<Style> StyleRepository { get; }

        User GetCurrentUser();
        Company GetCurrentCompany();
        void SaveChanges();
        void SaveChangesAsync();
    }
}
