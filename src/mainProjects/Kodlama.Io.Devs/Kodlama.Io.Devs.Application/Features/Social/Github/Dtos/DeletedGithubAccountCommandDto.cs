using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Common.AutoMapper;
using Kodlama.Io.Devs.Domain.Entities;

namespace Kodlama.Io.Devs.Application.Features.Social.Github.Dtos
{
    public class DeletedGithubAccountCommandDto : IReverseMapWith<GithubAccount>
    {
        public string? Username { get; set; }
        public string? Url { get; set; }
        public int PublicRepos { get; set; }
    }
}