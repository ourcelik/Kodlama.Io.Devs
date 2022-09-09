using AutoMapper;
using Core.Application.Common.AutoMapper;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageByIdCommand : IRequest<DeletedProgrammingLanguageDto>, IReverseMapWith<ProgrammingLanguage>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageByIdCommand, DeletedProgrammingLanguageDto>
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

            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageByIdCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguageFromDb = await _languageRepository.GetAsync((pl) => pl.Id == request.Id);

                _businessRules.IsProgrammingLanguageExistInDb(programmingLanguageFromDb);

                ProgrammingLanguage deletedLanguage = await _languageRepository.DeleteAsync(programmingLanguageFromDb);
                
                DeletedProgrammingLanguageDto deletedLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedLanguage);
                
                return deletedLanguageDto;
            }

        }
    }
}
