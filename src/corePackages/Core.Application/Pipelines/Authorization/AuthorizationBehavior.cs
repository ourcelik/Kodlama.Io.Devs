using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Security.Extensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Core.CrossCuttingConcerns.Exceptions;

namespace Core.Application.Pipelines.Authorization
{
    public class AuthorizationBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse>
    where TRequest : IRequest<TResponse>,ISecuredRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            List<string>? roles = _httpContextAccessor.HttpContext.User.ClaimRoles();
            if(roles == null || !roles.Any())
                throw new UnauthorizedAccessException("You are not authorized to access this resource");

            bool isNotMatchedARoleClaimWithRequestRoles =
            roles.FirstOrDefault(roleClaim => request.Roles.Any(role => role == roleClaim)).IsNullOrEmpty();
        if (isNotMatchedARoleClaimWithRequestRoles) throw new AuthorizationException("You are not authorized.");
            return await next();
        }
    }
}