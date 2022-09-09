using AutoMapper;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology
{
    public class DeleteProgrammingLanguageTechnologyCommand : IRequest<DeletedProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageTechnologyCommandHandler : IRequestHandler<DeleteProgrammingLanguageTechnologyCommand, DeletedProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public DeleteProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<DeletedProgrammingLanguageTechnologyDto> Handle(DeleteProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync((plt) => plt.Id == request.Id);

                programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.DeleteAsync(programmingLanguageTechnology);

                return _mapper.Map<DeletedProgrammingLanguageTechnologyDto>(programmingLanguageTechnology);
            }
        }
    }
}
