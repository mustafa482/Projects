using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jwt4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExapmleJwtController : ControllerBase
    {
        private IConfiguration _configuration;

        public ExapmleJwtController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public string Get(string userName,string password)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,userName),
                new Claim(ClaimTypes.Email,userName)
            };

            var creditials = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingcredentials = new SigningCredentials(creditials, SecurityAlgorithms.HmacSha256);



            var jwtsecurityToken = new JwtSecurityToken(
              issuer: _configuration["Jwt:Issuer"],
              audience: _configuration["Jwt:Audience"],
              claims:claims,
              expires:DateTime.Now.AddDays(15),
              notBefore:DateTime.Now,
              signingCredentials:signingcredentials

                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtsecurityToken);
            return token;

        }
        [HttpGet("Validate")]
        public bool ValidateToken(string token)
        {
            var creditials = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            
            try
            {
                JwtSecurityTokenHandler handler = new();
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = creditials,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                    






                }, out SecurityToken securityToken);




                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }
    }
}
