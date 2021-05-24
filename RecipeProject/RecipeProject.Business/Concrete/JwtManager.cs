using Microsoft.IdentityModel.Tokens;
using RecipeProject.Business.Interfaces;
using RecipeProject.Core.StringInfos;
using RecipeProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.Business.Concrete
{
    public class JwtManager : IJwtService
    {
        public string GenerateJwtToken(AppUser appUser, AppRole appRole)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: JwtInfo.Issuer, audience: JwtInfo.Audience, notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(JwtInfo.TokenExpiration), signingCredentials: signingCredentials, claims: GetClaims(appUser, appRole));
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwtSecurityToken);
        }
        private static List<Claim> GetClaims(AppUser appUser, AppRole appRole)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, appRole.RoleName));
            return claims;
        }
    }
}
