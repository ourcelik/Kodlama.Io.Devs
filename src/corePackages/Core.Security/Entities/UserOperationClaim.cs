using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class UserOperationCliam : Entity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public virtual User User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }

        public UserOperationCliam()
        {
            
        }

        public UserOperationCliam(int id, int userId, int operationClaimId) : base(id)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }
    }
}