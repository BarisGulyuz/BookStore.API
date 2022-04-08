using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Jwt
{
    public class JwtSettings
    {
        public const string Issuer = "http://localhost";
        public const string Audience = "http://localhost";
        public const string Key = "mybookstoresecretapikey";
        public const int Expire = 7;
    }
}
