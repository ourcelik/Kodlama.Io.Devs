using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Queries;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguages;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.Io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {   
        IHttpContextAccessor _httpContextAccessor;
        public ProgrammingLanguagesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            
            CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            Console.WriteLine(HttpContext.Request);
            
            return Created("", result);
        }

        [HttpDelete("DeleteByName")]
        public async Task<IActionResult> Delete(DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto result = await Mediator.Send(deleteProgrammingLanguageCommand);

            return Ok(result);
        }
        
        [HttpDelete()]
        public async Task<IActionResult> Delete(DeleteProgrammingLanguageByIdCommand deleteProgrammingLanguageByIdCommand)
        {
            DeletedProgrammingLanguageDto result = await Mediator.Send(deleteProgrammingLanguageByIdCommand);

            return Ok(result);
        }
        
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery]GetProgrammingLanguageByIdQuery getProgrammingLanguageByIdQuery)
        {
            
            GetProgrammingLanguageByIdDto result = await Mediator.Send(getProgrammingLanguageByIdQuery);

            return Ok(result);
        }


        [HttpGet("GetPage")]
        public async Task<IActionResult> GetPage([FromQuery]PageRequest pageRequest)
        {
            GetProgrammingLanguageListQuery listQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(listQuery);
            
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageDto result =  await Mediator.Send(updateProgrammingLanguageCommand);

            return Ok(result);

        }


    }
}
