using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Kodlama.Io.Devs.Domain.Entities;

namespace Kodlama.Io.Devs.Application.Services.Repositories.Social
{
    public interface IGithubRepository : IAsyncRepository<GithubAccount>,IRepository<GithubAccount>
    {
        
    }
}