using HumanResource.Models;
using HumanResource.Services.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController: ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
    
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            return Ok(_employeeService.GetEmployee());
        }
    
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            return Ok(_employeeService.GetEmployeeById(id));
        }
    
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            if(ModelState.IsValid)
                return Ok(_employeeService.CreateEmployee(employee));
    
            return BadRequest("Validation Issue");
        }
    
        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            if (ModelState.IsValid && employee.Id != null)
                return Ok(_employeeService.UpdateEmployee(employee));
            
            return BadRequest("Validation Issue");
        }
    
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            return Ok(_employeeService.DeleteEmploye(id));
        }
    }
}
