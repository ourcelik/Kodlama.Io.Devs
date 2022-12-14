using Core.Application.Common.AutoMapper;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos
{
    public class CreatedProgrammingLanguageDto :IReverseMapWith<ProgrammingLanguage>
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
