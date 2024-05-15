using Industrial_Engineering.Modals;
using System.Security.Claims;

namespace Industrial_Engineering.Data
{
    public class IndustrialEngineeringUnitOfWork : IIndustrialEngineeringUnitOfWork
    {
        private readonly User user;
        private readonly int userId;
        private readonly int companyId;
        private readonly IndustrialEngineeringDbContext dbContext;
        private readonly ILogger logger;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string userIdentifier;

        private IBaseRepository<Department> departmentRepository;
        private IBaseRepository<Designation> designationRepository;
        private IBaseRepository<Employee> employeeRepository;
        private IBaseRepository<ProductionFloor> productionFloorRepository;
        private IBaseRepository<FlowWorker> flowWorkerRepository;
        private IBaseRepository<Style> styleRepository;

        public IndustrialEngineeringUnitOfWork(IndustrialEngineeringDbContext dbContext, ILogger<IndustrialEngineeringDbContext> logger, IHttpContextAccessor contextAccessor)
        {
            this.dbContext = dbContext;
            this.logger = logger;

            try
            {
                userIdentifier = contextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
                user = dbContext.Users.Where(u => u.UserIdentifier == userIdentifier).FirstOrDefault();

                if (user == null)
                {
                    throw new InvalidOperationException("User Invalid");
                }
                userId = user.Id;
                companyId = user.CompanyId;
            }
            catch (Exception ex) { }
        }

        public IBaseRepository<Department> DepartmentRepository
        {
            get
            {
                return departmentRepository ??= new BaseRepository<Department>(dbContext, logger, companyId, userId);
            }
        }

        public IBaseRepository<Designation> DesignationRepository
        {
            get
            {
                return designationRepository ??= new BaseRepository<Designation>(dbContext, logger, companyId, userId);
            }
        }

        public IBaseRepository<Employee> EmployeeRepository
        {
            get
            {
                return employeeRepository ??= new BaseRepository<Employee>(dbContext, logger, companyId, userId);
            }
        }

        public IBaseRepository<ProductionFloor> ProductionFloorRepository
        {
            get
            {
                return productionFloorRepository ??= new BaseRepository<ProductionFloor>(dbContext, logger, companyId, userId);
            }
        }

        public IBaseRepository<FlowWorker> FlowWorkerRepository
        {
            get
            {
                return flowWorkerRepository ??= new BaseRepository<FlowWorker>(dbContext, logger, companyId, userId);
            }
        }

        public IBaseRepository<Style> StyleRepository
        {
            get
            {
                return styleRepository ??= new BaseRepository<Style>(dbContext, logger, companyId, userId);
            }
        }

        public User GetCurrentUser()
        {
            return user;
        }

        public Company GetCurrentCompany()
        {
            return dbContext.Companies.FirstOrDefault(t => t.Id == user.CompanyId);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public async void SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
