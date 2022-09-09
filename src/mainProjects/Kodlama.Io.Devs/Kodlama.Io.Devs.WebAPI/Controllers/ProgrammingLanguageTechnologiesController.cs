using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnologyList;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnologyListByDynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.Io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageTechnologiesController : BaseController
    {

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute]GetProgrammingLanguageByIdQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }


        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody]Dynamic dynamic)
        {
            var result = await Mediator.Send(new GetProgrammingLanguageTechnologyListByDynamicQuery
            {
                PageRequest = pageRequest,
                Dynamic = dynamic
            });

            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest)
        {
            var result = await Mediator.Send(new GetProgrammingLanguageTechnologyListQuery
            {
                PageRequest = pageRequest
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateProgrammingLanguageTechnologyCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]DeleteProgrammingLanguageTechnologyCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateProgrammingLanguageTechnologyCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

    }


}
