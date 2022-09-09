using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Security.Entities;

namespace Core.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);

        RefreshToken CreateRefreshToken(User user,string ipAddress);
    }
}