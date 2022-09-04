using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguagesBusinessRules
    {
        IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguagesBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task IsProgrammingLanguageNameUnique(string name)
        {
            var programmingLanguage = await _programmingLanguageRepository.GetAsync(pl => pl.Name == name);
            if(programmingLanguage != null)
                throw new BusinessException("Brand name exists.");
        }

        public void IsProgrammingLanguageExistInDb(ProgrammingLanguage? language)
        {
            if (language == null) throw new BusinessException("Does not exist");
        }
    }
}
