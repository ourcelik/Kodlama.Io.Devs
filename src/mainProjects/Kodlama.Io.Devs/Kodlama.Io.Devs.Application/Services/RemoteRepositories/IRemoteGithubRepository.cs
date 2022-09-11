using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kodlama.Io.Devs.Application.Features.Social.Github.Dtos;

namespace Kodlama.Io.Devs.Application.Services.RemoteRepositories
{
    public interface IRemoteGithubRepository
    {
        public Task<CreatedGithubAccountCommandDto> CompleteGithubAccountAsync(string username);
    }
}