using AutoMapper;
using Core.Application.Common.AutoMapper;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology
{
    public class CreateProgrammingLanguageTechnologyCommand : IRequest<CreatedProgrammingLanguageTechnologyDto>,IReverseMapWith<ProgrammingLanguageTechnology>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }


        public class CreateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<CreateProgrammingLanguageTechnologyCommand, CreatedProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public CreateProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<CreatedProgrammingLanguageTechnologyDto> Handle(CreateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);

                programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.AddAsync(programmingLanguageTechnology);

                return _mapper.Map<CreatedProgrammingLanguageTechnologyDto>(programmingLanguageTechnology);
            }
        }
    }
}
