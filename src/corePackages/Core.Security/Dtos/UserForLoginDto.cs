using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Security.JWT;

namespace Core.Security.Dtos
{
    public class UserForLoginDto
    {
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AuthenticatorCode { get; set; }
        public AccessToken? AccessToken { get; set; }

    }
}