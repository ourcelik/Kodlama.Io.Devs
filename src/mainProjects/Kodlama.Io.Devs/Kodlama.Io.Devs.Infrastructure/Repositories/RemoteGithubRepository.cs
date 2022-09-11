using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Kodlama.Io.Devs.Application.Features.Social.Github.Dtos;
using Kodlama.Io.Devs.Application.Services.RemoteRepositories;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Kodlama.Io.Devs.Infrastructure.Repositories
{
    public class RemoteGithubRepository : IRemoteGithubRepository
    {
        public string? BaseUrl { get; set; }
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public RemoteGithubRepository(HttpClient httpClient, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            BaseUrl = "https://api.github.com/users/";
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<CreatedGithubAccountCommandDto> CompleteGithubAccountAsync(string username)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("User-Agent", "request");
            //add bearer token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["Github:Token"]);
            client.BaseAddress = new Uri(BaseUrl);

            var response = await client.GetAsync(username);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dynamic githubAccount = JsonConvert.DeserializeObject<dynamic>(content);
                return new CreatedGithubAccountCommandDto
                {
                    Username = githubAccount.login,
                    Url = githubAccount.html_url,
                    PublicRepos = githubAccount.public_repos
                };
            }
            return null;
        }
    }
}