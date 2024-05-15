using HumanResource.Data;
using HumanResource.Models;
using HumanResource.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Services;

public class EmployeeService: IEmployeeService
{
    private readonly HumanResourceDbContext _dbContext;
    private readonly IHumanResourceUnitOfWork _unitOfWork;
    
    public EmployeeService(HumanResourceDbContext dbContext, IHumanResourceUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _unitOfWork = unitOfWork;
    }

    public List<Employee> GetEmployee()
    {
        List<Employee> employee = _unitOfWork.EmployeeRepository.GetAll().Include(e => e.Designation).Include(e => e.Department).Include(e => e.Company).ToList();
        return employee;
    }

    public Employee GetEmployeeById(int id)
    {
        Employee employee = _unitOfWork.EmployeeRepository.GetAll().Include(e => e.Designation).Include(e => e.Department).Include(e => e.Company).Where(e => e.Id == id).FirstOrDefault();
        return employee;
    }
    
    public Employee CreateEmployee(Employee employee)
    {
        Employee currentEmp = _unitOfWork.EmployeeRepository.GetAll().Where(e => e.NIC == employee.NIC).FirstOrDefault();
        if (currentEmp != null)
            throw new Exception("Employee NIC already have in the database.");
        
        _unitOfWork.EmployeeRepository.Insert(employee);
        _unitOfWork.SaveChanges();
        _unitOfWork.EmployeeRepository.Reload(employee);
        return employee;
    }

    public Employee UpdateEmployee(Employee employee)
    {
        _unitOfWork.EmployeeRepository.Update(employee);
        _unitOfWork.SaveChanges();
        _unitOfWork.EmployeeRepository.Reload(employee);

        return employee;
    }

    public Employee DeleteEmploye(int id)
    {
        Employee employee = _unitOfWork.EmployeeRepository.GetAll().Where(e => e.Id == id).FirstOrDefault();
        if (employee == null)
            throw new Exception("Employee not found!");
        
        _unitOfWork.EmployeeRepository.Delete(employee);
        _unitOfWork.SaveChanges();
        return employee;
    }
}