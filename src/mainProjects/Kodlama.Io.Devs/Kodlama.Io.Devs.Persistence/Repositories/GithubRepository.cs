using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Kodlama.Io.Devs.Application.Services.Repositories.Social;
using Kodlama.Io.Devs.Domain.Entities;
using Kodlama.Io.Devs.Persistence.Contexts;

namespace Kodlama.Io.Devs.Persistence.Repositories
{
    public class GithubRepository : EfRepositoryBase<GithubAccount,BaseDbContext>, IGithubRepository
    {
        public GithubRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}