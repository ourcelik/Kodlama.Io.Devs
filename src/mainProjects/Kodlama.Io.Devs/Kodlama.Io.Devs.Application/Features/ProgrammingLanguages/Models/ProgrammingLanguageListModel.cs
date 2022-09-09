using Core.Application.Common.AutoMapper;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Models
{
    public class ProgrammingLanguageListModel : BasePageableModel,IReverseMapWith<IPaginate<ProgrammingLanguage>>
    {
        public IList<ProgrammingLanguageListDto>? Items { get; set; }
    }
}
