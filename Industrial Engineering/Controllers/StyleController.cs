using Industrial_Engineering.Modals;
using Industrial_Engineering.Services.Context;
using Microsoft.AspNetCore.Mvc;

namespace Industrial_Engineering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleController : ControllerBase
    {
        protected readonly IStyleService _styleService;

        public StyleController(IStyleService styleService)
        {
            _styleService = styleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Style>>> GetStyles()
        {
            return _styleService.GetStyles();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Style>> GetStyleById(int id)
        {
            return _styleService.GetStyleById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Style>> PostStyle(Style style)
        {
            return _styleService.CreateStyle(style);
        }

        [HttpPut]
        public async Task<ActionResult<Style>> PutStyle(Style style)
        {
            return _styleService.UpdateStyle(style);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Style>> DeleteStyle(int id)
        {
            return _styleService.DeleteStyle(id);
        }
    }
}
