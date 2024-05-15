using System.Security.Claims;
using HumanResource.Models;

namespace HumanResource.Data
{
    public class HumanResourceUnitOfWork: IHumanResourceUnitOfWork
    {
        private readonly User user;
        private readonly int userId;
        private readonly int companyId;
        private readonly HumanResourceDbContext dbContext;
        private readonly ILogger logger;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string userIdentifier;

        private IBaseRepository<Department> departmentRepository;
        private IBaseRepository<Designation> designationRepository;
        private IBaseRepository<Employee> employeeRepository;
        
        public HumanResourceUnitOfWork(HumanResourceDbContext dbContext, ILogger<HumanResourceDbContext> logger, IHttpContextAccessor contextAccessor)
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

