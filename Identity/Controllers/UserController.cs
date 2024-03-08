using Identity.Modals;
using Identity.Repositories.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        protected readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("userDetails")]
        public async Task<ActionResult<User>> GetUserDetails()
        {
            var user = await _userRepository.GetUserData();
            return Ok(user);
        }
    }
}
