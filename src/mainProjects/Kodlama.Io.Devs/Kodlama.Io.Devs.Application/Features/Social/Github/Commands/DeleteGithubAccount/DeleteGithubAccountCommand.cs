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

namespace Kodlama.Io.Devs.Application.Features.Social.Github.Commands.DeleteGithubAccount
{
    public class DeleteGithubAccountCommand : IRequest<DeletedGithubAccountCommandDto>
    {
        public class DeleteGithubAccountCommandHandler : IRequestHandler<DeleteGithubAccountCommand, DeletedGithubAccountCommandDto>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly GithubBusinessRules _githubBusinessRules;


            public DeleteGithubAccountCommandHandler(IGithubRepository githubRepository, IRemoteGithubRepository githubRemoteRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, GithubBusinessRules githubBusinessRules)
            {
                _githubRepository = githubRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
                _githubBusinessRules = githubBusinessRules;
            }
            public async Task<DeletedGithubAccountCommandDto> Handle(DeleteGithubAccountCommand request, CancellationToken cancellationToken)
            {
                int userId = _httpContextAccessor.HttpContext.User.GetUserId();
                GithubAccount githubAccount = await _githubRepository.GetAsync(g => g.UserId == userId);
                _githubBusinessRules.CheckIfGithubAccountExists(githubAccount);
                GithubAccount deletedAccount = await _githubRepository.DeleteAsync(githubAccount);
                return _mapper.Map<DeletedGithubAccountCommandDto>(deletedAccount);
            }
        }
    }
}