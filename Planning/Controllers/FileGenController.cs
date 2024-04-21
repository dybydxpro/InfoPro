using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}
