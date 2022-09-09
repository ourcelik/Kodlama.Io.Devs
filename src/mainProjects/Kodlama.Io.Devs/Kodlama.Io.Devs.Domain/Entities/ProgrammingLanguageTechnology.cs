using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Domain.Entities
{
    public class ProgrammingLanguageTechnology : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        
        public string? Name { get; set; }
        
        public ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public ProgrammingLanguageTechnology(){}

        public ProgrammingLanguageTechnology(int id,int programmingLanguageId, string name) : this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
        }
    }
}
