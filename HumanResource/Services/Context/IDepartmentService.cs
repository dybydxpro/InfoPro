using HumanResource.Models;

namespace HumanResource.Services.Context
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
        Department GetDepartmentById(int id);
        Department CreateDepartment(Department department);
        Department UpdateDepartment(Department department);
        Department DeleteDepartment(int id);
    }
}