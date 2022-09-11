using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.Io.Devs.Domain.Entities
{
    public class GithubAccount : Entity
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Url { get; set; }
        public int PublicRepos { get; set; }
        public User User { get; set; }

        public GithubAccount(string? username, string? url, int publicRepos)
        {
            Username = username;
            Url = url;
            PublicRepos = publicRepos;
        }
    }
}