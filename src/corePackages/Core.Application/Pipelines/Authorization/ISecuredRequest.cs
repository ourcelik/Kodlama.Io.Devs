using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Authorization
{
    public interface ISecuredRequest
    {
        public string[] Roles { get; }
    }
}