using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnologyList
{
    public class GetProgrammingLanguageTechnologyListQuery : IRequest<ProgrammingLanguageTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetProgrammingLanguageTechnologyListQueryHandler : IRequestHandler<GetProgrammingLanguageTechnologyListQuery, ProgrammingLanguageTechnologyListModel>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public GetProgrammingLanguageTechnologyListQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetProgrammingLanguageTechnologyListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguageTechnology> techFromDb = await _programmingLanguageTechnologyRepository
                                                                 .GetListAsync(index: request.PageRequest.Page
                                                                               , size: request.PageRequest.PageSize
                                                                               , include: x => x.Include(y => y.ProgrammingLanguage));

                ProgrammingLanguageTechnologyListModel mappedTech = _mapper.Map<ProgrammingLanguageTechnologyListModel>(techFromDb);

                return mappedTech;
            }
        }
    }
}
