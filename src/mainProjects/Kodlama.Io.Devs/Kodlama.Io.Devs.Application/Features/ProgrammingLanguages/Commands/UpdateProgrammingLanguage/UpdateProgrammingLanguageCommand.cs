using AutoMapper;
using Core.Application.Common;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>,IReverseMapWith<ProgrammingLanguage>
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            IProgrammingLanguageRepository _programmingLanguageRepository;
            IMapper _mapper;
            ProgrammingLanguagesBusinessRules _businessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguagesBusinessRules businessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? languageFromDb = await _programmingLanguageRepository.GetAsync(pl => pl.Id == request.Id,false);
                _businessRules.IsProgrammingLanguageExistInDb(languageFromDb);
                ProgrammingLanguage mappedLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage? updatedProgramingLanguage = await _programmingLanguageRepository.UpdateAsync(mappedLanguage);
                
                UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgramingLanguage);

                return updatedProgrammingLanguageDto;
            }
        }
    }
}
