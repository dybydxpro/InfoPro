using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planning.Models;
using Planning.Services.Context;

namespace Planning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlanStructController : ControllerBase
    {
        protected readonly IPlanStructService _planStructService;

        public PlanStructController(IPlanStructService planStructService)
        {
            _planStructService = planStructService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlanStruct>>> GetAllPlanStructs()
        {
            return Ok(_planStructService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PlanStruct>> GetPlanStructById(int id)
        {
            return Ok(_planStructService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<PlanStruct>> PostPlanStruct(PlanStruct planStruct)
        {
            return Ok(_planStructService.PostPlanStruct(planStruct));
        }

        [HttpPut]
        public async Task<ActionResult<PlanStruct>> PutPlanStruct(PlanStruct planStruct)
        {
            return Ok(_planStructService.PutPlanStruct(planStruct));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<PlanStruct>> DeletePlanStruct(int id)
        {
            return Ok(_planStructService.DeletePlanStruct(id));
        }
    }
}
