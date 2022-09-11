using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kodlama.Io.Devs.Application.Features.Social.Github.Commands.AddGithubAccount;
using Kodlama.Io.Devs.Application.Features.Social.Github.Commands.DeleteGithubAccount;
using Kodlama.Io.Devs.Application.Features.Social.Github.Commands.UpdateGithubAccount;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.Io.Devs.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GithubController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddGithubAccount([FromBody] CreateGithubAccountCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGithubAccount([FromBody] UpdateGithubAccountCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGithubAccount([FromBody] DeleteGithubAccountCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}