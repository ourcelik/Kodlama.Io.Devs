using Core.Application.Common.AutoMapper;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos
{
    public class CreatedProgrammingLanguageTechnologyDto : IReverseMapWith<ProgrammingLanguageTechnology>
    {
        public string Name { get; set; }

        public int ProgrammingLanguageId { get; set; }
    }
}
