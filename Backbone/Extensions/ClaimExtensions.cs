using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Backbone.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }
        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }
        public static void AddNameIdentifier(this ICollection<Claim> claims, string namaIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, namaIdentifier));
        }
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
