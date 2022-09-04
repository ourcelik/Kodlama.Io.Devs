using AutoMapper;
using Core.Application.Common;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguages
{
    public class GetProgrammingLanguageListQuery : IRequest<ProgrammingLanguageListModel>,IReverseMapWith<ProgrammingLanguage>
    {
        public PageRequest PageRequest { get; set; }

        public class GetProgrammingLanguageListQueryHandler : IRequestHandler<GetProgrammingLanguageListQuery, ProgrammingLanguageListModel>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;

            public GetProgrammingLanguageListQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
            }

            public async Task<ProgrammingLanguageListModel> Handle(GetProgrammingLanguageListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> languages = await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ProgrammingLanguageListModel mappedProgrammingListModel = _mapper.Map<ProgrammingLanguageListModel>(languages);

                return mappedProgrammingListModel;
            }
        }
    }
}
