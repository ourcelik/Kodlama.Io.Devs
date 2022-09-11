using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Security.Extensions;
using Kodlama.Io.Devs.Application.Features.Social.Github.Dtos;
using Kodlama.Io.Devs.Application.Features.Social.Github.Rules;
using Kodlama.Io.Devs.Application.Services.RemoteRepositories;
using Kodlama.Io.Devs.Application.Services.Repositories.Social;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Kodlama.Io.Devs.Application.Features.Social.Github.Commands.AddGithubAccount
{
    public class CreateGithubAccountCommand : IRequest<CreatedGithubAccountCommandDto>
    {
        public string Username { get; set; }

        public class CreateGithubAccountCommandHandler : IRequestHandler<CreateGithubAccountCommand, CreatedGithubAccountCommandDto>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly IRemoteGithubRepository _remoteGithubRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            private readonly GithubBusinessRules _githubBusinessRules;

            public CreateGithubAccountCommandHandler(IGithubRepository githubRepository,
                                                    IMapper mapper,
                                                    IRemoteGithubRepository remoteGithubRepository,
                                                    IHttpContextAccessor httpContextAccessor,
                                                    GithubBusinessRules githubBusinessRules)
            {
                _githubRepository = githubRepository;
                _mapper = mapper;
                _remoteGithubRepository = remoteGithubRepository;
                _httpContextAccessor = httpContextAccessor;
                _githubBusinessRules = githubBusinessRules;
            }

            public async Task<CreatedGithubAccountCommandDto> Handle(CreateGithubAccountCommand request, CancellationToken cancellationToken)
            {
                CreatedGithubAccountCommandDto githubAccount = await _remoteGithubRepository.CompleteGithubAccountAsync(request.Username);
                _githubBusinessRules.CheckIfGithubAccountExists(githubAccount);
                GithubAccount githubAccountEntity = _mapper.Map<GithubAccount>(githubAccount);
                githubAccountEntity.UserId = _httpContextAccessor.HttpContext.User.GetUserId();
                await _githubRepository.AddAsync(githubAccountEntity);



                return _mapper.Map<CreatedGithubAccountCommandDto>(githubAccountEntity);
            }
        }
    }

}