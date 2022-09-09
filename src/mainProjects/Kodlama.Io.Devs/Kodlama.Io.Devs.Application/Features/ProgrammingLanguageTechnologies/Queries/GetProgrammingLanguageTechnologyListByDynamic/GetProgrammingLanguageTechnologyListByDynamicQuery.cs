using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
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

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnologyListByDynamic
{
    public class GetProgrammingLanguageTechnologyListByDynamicQuery : IRequest<ProgrammingLanguageTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }

        public class GetProgrammingLanguageTechnologyListByDynamicQueryHandler : IRequestHandler<GetProgrammingLanguageTechnologyListByDynamicQuery, ProgrammingLanguageTechnologyListModel>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public GetProgrammingLanguageTechnologyListByDynamicQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetProgrammingLanguageTechnologyListByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguageTechnology> techFromDb = await _programmingLanguageTechnologyRepository
                                                                  .GetListByDynamicAsync(
                                                                    dynamic:request.Dynamic
                                                                  , include: x => x.Include(y => y.ProgrammingLanguage)
                                                                  , index: request.PageRequest.Page
                                                                  ,size: request.PageRequest.PageSize);
                ProgrammingLanguageTechnologyListModel mappedTech = _mapper.Map<ProgrammingLanguageTechnologyListModel>(techFromDb);

                return mappedTech;
                
                
            }
        }
    }
}
