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

namespace Kodlama.Io.Devs.Application.Features.Social.Github.Commands.UpdateGithubAccount
{
    public class UpdateGithubAccountCommand : IRequest<UpdatedGithubAccountCommandDto>
    {
        public string? Username { get; set; }

        public class UpdateGithubAccountCommandHandler : IRequestHandler<UpdateGithubAccountCommand, UpdatedGithubAccountCommandDto>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly IRemoteGithubRepository _githubRemoteRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            private readonly GithubBusinessRules _githubBusinessRules;

            public UpdateGithubAccountCommandHandler(IGithubRepository githubRepository, IRemoteGithubRepository githubRemoteRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, GithubBusinessRules githubBusinessRules)
            {
                _githubRepository = githubRepository;
                _githubRemoteRepository = githubRemoteRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
                _githubBusinessRules = githubBusinessRules;
            }

            public async Task<UpdatedGithubAccountCommandDto> Handle(UpdateGithubAccountCommand request, CancellationToken cancellationToken)
            {
                var UserId = _httpContextAccessor.HttpContext.User.GetUserId();
                var githubAccountFromDb = await _githubRepository.GetAsync(g => g.UserId == UserId,false);
                _githubBusinessRules.CheckIfGithubAccountExists(githubAccountFromDb);
                var githubAccount = await _githubRemoteRepository.CompleteGithubAccountAsync(request.Username);
                _githubBusinessRules.CheckIfGithubAccountExists(githubAccount);
                var mappedGithubAccount = _mapper.Map<GithubAccount>(githubAccount);
                mappedGithubAccount.Id = githubAccountFromDb.Id;
                mappedGithubAccount.UserId = UserId;

                var githubAccountDto = await _githubRepository.UpdateAsync(mappedGithubAccount);

                return _mapper.Map<UpdatedGithubAccountCommandDto>(githubAccountDto);
            }
        }

    }
}