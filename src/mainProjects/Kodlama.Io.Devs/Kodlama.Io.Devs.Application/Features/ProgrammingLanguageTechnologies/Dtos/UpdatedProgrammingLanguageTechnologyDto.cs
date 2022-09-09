using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Common.AutoMapper;
using Kodlama.Io.Devs.Domain.Entities;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos
{
    public class UpdatedProgrammingLanguageTechnologyDto : IReverseMapWith<ProgrammingLanguageTechnology>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
