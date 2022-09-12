using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kodlama.Io.Devs.Domain.Entities;

namespace Kodlama.Io.Devs.Application.Features.Social.Github.Rules
{
    public class GithubBusinessRules
    {
        internal void CheckIfGithubAccountExists<T>(T githubAccountFromDb)
        {
            if (githubAccountFromDb == null)
            {
                throw new Exception("Github account not found");
            }
        }
    }
}