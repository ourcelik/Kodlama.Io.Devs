using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Domain.Entities
{
    public class ProgrammingLanguage : Entity
    {
        public string? Name { get; set; }

        public ICollection<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }

        public ProgrammingLanguage(string name)
        {
            Name = name;
        }
        public ProgrammingLanguage(int id,string name)
        {
            Id = id;
            Name = name;
        }
    }
}
