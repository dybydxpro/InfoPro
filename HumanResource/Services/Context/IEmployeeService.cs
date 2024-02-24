using HumanResource.Models;

namespace HumanResource.Services.Context;

public interface IEmployeeService
{
    List<Employee> GetEmployee();
    Employee GetEmployeeById(int id);
    Employee CreateEmployee(Employee employee);
    Employee UpdateEmployee(Employee employee);
    Employee DeleteEmploye(int id);
}