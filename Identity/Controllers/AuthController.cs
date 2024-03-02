﻿using Identity.Modals.Auth;
using Identity.Repositories.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;

        public AuthController(IAuthRepository authRepository) {
            this.authRepository = authRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<(int, string)>> Login(LoginModel model)
        {
            var (status, message) = await authRepository.Login(model);
            if (status == 0)
                return BadRequest(message);
            return Ok(message);
        }

        [HttpPost]
        [Route("register/{role}")]
        [AllowAnonymous]
        public async Task<ActionResult<(int, string)>> Register(RegistrationModel model, string role)
        {
            return Ok(await authRepository.Registeration(model, role));
        }

        [HttpGet]
        [Route("test")]
        public async Task<ActionResult<(int, string)>> Test()
        {
            return Ok("Hi! I'm working");
        }
    }
}
