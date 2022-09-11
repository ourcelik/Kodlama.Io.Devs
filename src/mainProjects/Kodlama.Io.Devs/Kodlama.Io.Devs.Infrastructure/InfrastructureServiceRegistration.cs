using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kodlama.Io.Devs.Application.Services.RemoteRepositories;
using Kodlama.Io.Devs.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.Io.Devs.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IRemoteGithubRepository, RemoteGithubRepository>();
            return services;
        }
    }
}