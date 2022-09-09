using AutoMapper;
using Core.Application.Common.AutoMapper;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>,IReverseMapWith<ProgrammingLanguage>
    {
        public string? Name { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository? _programmingLanguageRepository;
            private IMapper? _mapper;
            private readonly ProgrammingLanguagesBusinessRules? _programmingLanguagesBusinessRules;

            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository? programmingLanguageRepository, IMapper? mapper, ProgrammingLanguagesBusinessRules? programmingLanguagesBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
            }

            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguagesBusinessRules.IsProgrammingLanguageNameUnique(request.Name);
                
                ProgrammingLanguage mappedLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createdLanguage = await _programmingLanguageRepository.AddAsync(mappedLanguage);
                CreatedProgrammingLanguageDto languageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdLanguage);
                
                return languageDto;
                
            }
        }
    }
}
