using Core.Application.Common.AutoMapper;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguageTechnologies.Models
{
    public class ProgrammingLanguageTechnologyListModel : BasePageableModel,IReverseMapWith<IPaginate<ProgrammingLanguageTechnology>>
    {
        public IList<ProgrammingLanguageTechnologyListDto> Items { get; set; }
    }
}
