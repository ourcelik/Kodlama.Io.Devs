using Core.Persistence.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Services.Repositories
{
    public interface IProgrammingLanguageTechnologyRepository :IAsyncRepository<ProgrammingLanguageTechnology>,IRepository<ProgrammingLanguageTechnology>
    {
        
    }
}
