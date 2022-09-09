using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Common.AutoMapper
{
    public static class AutoProfileMapperHelper
    {

        public static void ApplyMappingsFromAssembly(Assembly assembly, Profile profile)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IReverseMapWith<>))).ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping")
                        ?? type?.GetInterface("IReverseMapWith`1")?.GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { profile });
            }
        }
    }
}
