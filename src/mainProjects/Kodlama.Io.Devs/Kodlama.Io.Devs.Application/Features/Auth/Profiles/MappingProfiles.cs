using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Kodlama.Io.Devs.Application.Features.Auth.Commands.Login;
using Kodlama.Io.Devs.Application.Features.Auth.Commands.Register;

namespace Kodlama.Io.Devs.Application.Features.Auth.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserForRegisterDto, User>().ReverseMap();
            CreateMap<UserForLoginDto, User>().ReverseMap();
            CreateMap<LoginCommand,User>().ReverseMap();
            CreateMap<RegisterCommand,User>().ReverseMap();
        }
        
    }
}