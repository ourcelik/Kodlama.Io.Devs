using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Security.JWT;

namespace Core.Security.Dtos
{
    public class UserForRegisterDto
    {
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public AccessToken? Token { get; set; }
    }
}