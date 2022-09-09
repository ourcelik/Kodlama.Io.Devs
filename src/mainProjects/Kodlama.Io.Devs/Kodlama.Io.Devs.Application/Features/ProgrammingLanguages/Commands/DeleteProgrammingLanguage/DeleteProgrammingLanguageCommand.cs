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
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>,IReverseMapWith<ProgrammingLanguage>
    {
        public string Name { get; set; }

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
        {
            IProgrammingLanguageRepository _languageRepository;
            IMapper _mapper;
            ProgrammingLanguagesBusinessRules _businessRules;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository languageRepository, IMapper mapper, ProgrammingLanguagesBusinessRules businessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _businessRules = businessRules;  
            }

            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage programmingLanguageFromDb = await _languageRepository.GetAsync((pl) => pl.Name == request.Name)
                                                                    .ConfigureAwait(false);

                _businessRules.IsProgrammingLanguageExistInDb(programmingLanguageFromDb);

                ProgrammingLanguage deletedLanguage = await _languageRepository.DeleteAsync(programmingLanguageFromDb);
                DeletedProgrammingLanguageDto deletedLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedLanguage);   
                return deletedLanguageDto;
            }
        }
    }
}
