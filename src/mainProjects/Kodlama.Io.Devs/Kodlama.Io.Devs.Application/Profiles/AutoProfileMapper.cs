using AutoMapper;
using Core.Application.Common.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Profiles
{
    public class AutoProfileMapper : Profile
    {
        public AutoProfileMapper()
        {
            AutoProfileMapperHelper.ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly(), this);
        }
    }
}
