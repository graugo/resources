using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Net6CodeSample.WebApi.Autentication
{
    public class AutenticationService : IAutenticationService
    {
        private readonly IConfiguration _config;

        public AutenticationService(IConfiguration config)
        {
            _config = config;
        }

        public string Autenticate(string profile) 
        {
            var profileConfig = _config[$"Profiles:{profile.ToLower()}"];
            if (!string.IsNullOrEmpty(profileConfig)) 
            {
                return profileConfig;
            }
            return null;
        }

        public string Generate(string user) 
        {
            var security = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(security, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user),
                new Claim("hola", "hola")
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials
                );

            return  new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
