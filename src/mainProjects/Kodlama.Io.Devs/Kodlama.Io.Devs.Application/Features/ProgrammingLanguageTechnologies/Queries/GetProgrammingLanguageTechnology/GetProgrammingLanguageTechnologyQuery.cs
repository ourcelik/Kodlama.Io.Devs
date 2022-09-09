using AutoMapper;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnology
{
    public class GetProgrammingLanguageTechnologyQuery : IRequest<GetProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }

        public class GetProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetProgrammingLanguageTechnologyQuery, GetProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public GetProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<GetProgrammingLanguageTechnologyDto> Handle(GetProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageTechnology? languageTechnologyfromDb = await _programmingLanguageTechnologyRepository.
                                                                                    GetAsync((plt) => plt.Id == request.Id);
                
                GetProgrammingLanguageTechnologyDto languageTechnologymapped = _mapper.Map<GetProgrammingLanguageTechnologyDto>(languageTechnologyfromDb);

                return languageTechnologymapped;
            }
        }
    }
}
