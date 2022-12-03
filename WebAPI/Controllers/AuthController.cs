using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration Config;

        public AuthController(IConfiguration configuration)
        {
            Config = configuration;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody]Credential credential)
        {
            if (credential is not null)
            {
                if (credential.UserName == "admin" && credential.Password == "password")
                {
                    List<Claim>? claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, credential.UserName),
                        new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
                        new Claim("HR", "HRDepartment"),
                        new Claim("Admin", "AdminDepartment"),
                        new Claim("EmploymentDate", "2022-01-01")
                    };

                    DateTime expiresAt = DateTime.UtcNow.AddMinutes(30);

                    return Ok(new
                    {
                        access_token = GenerateToken(claims, expiresAt),
                        expires_at = expiresAt,
                    });

                }
            }

            ModelState.AddModelError("Unauthorized", "You are not authorized to access the endpoint");
            return Unauthorized(ModelState);
        }

        private string GenerateToken(IEnumerable<Claim> claims, DateTime expiresAt)
        {

            byte[]? secretKey =
                Encoding.UTF8.GetBytes(Config.GetValue<string>("SecretKey"));

            JwtSecurityToken? jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiresAt,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey), 
                    SecurityAlgorithms.HmacSha256Signature));

            return 
                new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
