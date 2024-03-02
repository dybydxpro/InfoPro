using HumanResource.Models;
using HumanResource.Services.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        protected readonly IDepartmentService _departmentService;
        
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            return Ok(_departmentService.GetDepartments());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Department>> GetDepartemntById(int id)
        {
            return Ok(_departmentService.GetDepartmentById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment(Department department)
        {
            return Ok(_departmentService.CreateDepartment(department));
        }

        [HttpPut]
        public async Task<ActionResult<Department>> UpdateDepartment(Department department)
        {
            return Ok(_departmentService.UpdateDepartment(department));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            return Ok(_departmentService.DeleteDepartment(id));
        }
    }
}
