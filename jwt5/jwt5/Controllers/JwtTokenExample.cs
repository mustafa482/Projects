using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jwt5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtTokenExample : ControllerBase
    {
        private IConfiguration _configuartion;

        public JwtTokenExample(IConfiguration configuration)
        {
            _configuartion= configuration;
        }

        [HttpGet]
        public string Get(string username,string password)     
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Email,username)
            };

            var credentials = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuartion["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(credentials, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuartion["Jwt:Issuer"],
                audience: _configuartion["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                notBefore:DateTime.Now,
                signingCredentials:signingCredentials


                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;


         
        }
        [HttpGet("Validate")]
        public bool ValidateToken(string token)
        {
            var credentials = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuartion["Jwt:Key"]));
            try
            {
                JwtSecurityTokenHandler handler = new();
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = credentials,
                    ValidateLifetime = true




                },out SecurityToken securityToken);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
    }
}
