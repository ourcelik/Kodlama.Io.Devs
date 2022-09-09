using AutoMapper;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology
{
    public class UpdateProgrammingLanguageTechnologyCommand : IRequest<UpdatedProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageTechnologyCommand, UpdatedProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedProgrammingLanguageTechnologyDto> Handle(UpdateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync((plt) => plt.Id == request.Id,false);

                programmingLanguageTechnology.Name = request.Name;

                programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.UpdateAsync(programmingLanguageTechnology);

                return _mapper.Map<UpdatedProgrammingLanguageTechnologyDto>(programmingLanguageTechnology);
            }
        }
    }
}
