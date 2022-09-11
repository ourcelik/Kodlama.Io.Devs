using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kodlama.Io.Devs.Application.Features.Auth.Commands.Login;
using Kodlama.Io.Devs.Application.Features.Auth.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.Io.Devs.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            return Ok(await Mediator.Send(registerCommand));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            return Ok(await Mediator.Send(loginCommand));
        }
    }
}