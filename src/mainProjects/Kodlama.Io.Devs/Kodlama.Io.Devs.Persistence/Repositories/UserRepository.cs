using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.Io.Devs.Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }

        public Task<List<OperationClaim>> GetUserClaims(int userId)
        {
            IQueryable<OperationClaim> query = from user in Context.Users
                                               join userOperationClaim in Context.UserOperationClaims
                                                    on user.Id equals userOperationClaim.UserId
                                               join operationClaim in Context.OperationClaims
                                                    on userOperationClaim.OperationClaimId equals operationClaim.Id
                                                        where user.Id == userId
                                                select operationClaim;

            return query.ToListAsync();
        }
    }
}