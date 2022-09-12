using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Pipelines.Authentication
{
    public class AuthenticationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, IAuthRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            bool IsAuthenticated = _httpContextAccessor.HttpContext.User.IsAuthenticated();
            if(!IsAuthenticated) 
                throw new AuthenticationException("You should be loggedIn to access this resourse");
            return await next();
        }
    }
}