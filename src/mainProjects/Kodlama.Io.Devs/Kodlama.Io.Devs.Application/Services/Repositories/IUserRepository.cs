using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.Io.Devs.Application.Services.Repositories
{
    public interface IUserRepository : IRepository<User>,IAsyncRepository<User>
    {
        public Task<List<OperationClaim>> GetUserClaims(int userId);
    }
}