using AutoMapper;
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

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguage
{
    public class GetProgrammingLanguageByIdQuery : IRequest<GetProgrammingLanguageByIdDto>
    {
        public int Id { get; set; }

        public class GetProgrammingLanguageByIdQueryHandler : IRequestHandler<GetProgrammingLanguageByIdQuery, GetProgrammingLanguageByIdDto>
        {
            IProgrammingLanguageRepository _programmingLanguageRepository;
            IMapper _mapper;
            ProgrammingLanguagesBusinessRules _businessRules;

            public GetProgrammingLanguageByIdQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguagesBusinessRules businessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<GetProgrammingLanguageByIdDto> Handle(GetProgrammingLanguageByIdQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? languageFromDb = await _programmingLanguageRepository.GetAsync(pl => pl.Id == request.Id);
                _businessRules.IsProgrammingLanguageExistInDb(languageFromDb);

                GetProgrammingLanguageByIdDto languageByIdDto = _mapper.Map<GetProgrammingLanguageByIdDto>(languageFromDb);

                return languageByIdDto;

            }
        }
    }
}
