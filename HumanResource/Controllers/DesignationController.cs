using HumanResource.Models;
using HumanResource.Services.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DesignationController : ControllerBase
    {
        protected readonly IDesignationService _designationService;
        
        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Designation>>> GetDesignations()
        {
            return Ok(_designationService.GetDesignations());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Designation>> GetDesignationById(int id)
        {
            return Ok(_designationService.GetDesignationById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Designation>> CreateDesignation(Designation designation)
        {
            return Ok(_designationService.CreateDesignation(designation));
        }

        [HttpPut]
        public async Task<ActionResult<Designation>> UpdateDesignation(Designation designation)
        {
            return Ok(_designationService.UpdateDesignation(designation));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Designation>> DeleteDesignation(int id)
        {
            return Ok(_designationService.DeleteDesignation(id));
        }
    }
}
