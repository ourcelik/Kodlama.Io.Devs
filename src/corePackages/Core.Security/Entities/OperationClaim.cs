using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Enums;

namespace Core.Security.Entities
{
    public class OperationClaim : Entity
    {
        public string Name { get; set; }

        public OperationClaim()
        {

        }

        public OperationClaim(int id, string name) : base(id)
        {
            Name = name;
        }
    }





}