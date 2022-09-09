using AutoMapper;
using Core.Application.Common.AutoMapper;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguageTechnology, ProgrammingLanguageTechnologyListDto>()
                .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.ProgrammingLanguage.Name))
                .ReverseMap();

            CreateMap<ProgrammingLanguageTechnology, GetProgrammingLanguageTechnologyDto>()
                .ForMember(dest => dest.LanguageName,opt => opt.MapFrom(src => src.ProgrammingLanguage.Name))
                .ReverseMap();


        }
    }
}
