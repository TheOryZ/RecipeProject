using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.Core.StringInfos
{
    public class JwtInfo
    {
        public const string Issuer = "http://localhost";
        public const string Audience = "http://localhost";
        public const string SecurityKey = "johnDoejohnDoe23";
        public const double TokenExpiration = 30;
    }
}
