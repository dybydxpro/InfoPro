using HumanResource.Data;
using HumanResource.Models;
using HumanResource.Services.Context;

namespace HumanResource.Services
{
    public class DepartmentService : IDepartmentService
    {
        protected readonly HumanResourceDbContext _dbContext;
        protected readonly IHumanResourceUnitOfWork _unitOfWork;

        public DepartmentService(HumanResourceDbContext dbContext, IHumanResourceUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public List<Department> GetDepartments()
        {
            List<Department> department = _unitOfWork.DepartmentRepository.GetAll().ToList();
            return department;
        }

        public Department GetDepartmentById(int id)
        {
            Department department = _unitOfWork.DepartmentRepository.GetAll().Where(d => d.Id == id).FirstOrDefault();
            return department;
        }

        public Department CreateDepartment(Department department)
        {
            _unitOfWork.DepartmentRepository.Insert(department);
            _unitOfWork.SaveChanges();
            _unitOfWork.DepartmentRepository.Reload(department);
            return department;
        }

        public Department UpdateDepartment(Department department)
        {
            _unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.SaveChanges();
            _unitOfWork.DepartmentRepository.Reload(department);
            return department;
        }

        public Department DeleteDepartment(int id)
        {
            Department department = GetDepartmentById(id);
            if (department == null)
                throw new Exception("Departmenmt not found!");
            
            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.SaveChanges();
            return department;
        }
    }
}
