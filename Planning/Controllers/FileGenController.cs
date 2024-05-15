using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planning.Models;
using Planning.Services.Context;

namespace Planning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileGenController : ControllerBase
    {
        protected readonly IFileGenService _fileGenService;

        public FileGenController(IFileGenService fileGenService)
        {
            _fileGenService = fileGenService;
        }

        [HttpPost]
        [Route("planGen")]
        public async Task<ActionResult> HandleSpredsheets([FromForm] PreProcess preProcess)
        {
            var data = await _fileGenService.HandleSpredsheets(preProcess);
            var encode = new { file = data };
            return Ok(encode);
        }
    }
}
