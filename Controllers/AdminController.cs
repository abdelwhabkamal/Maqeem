using Microsoft.AspNetCore.Mvc;
using Maskan.DAL;
using Maskan.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Maskan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly MaskanContext _context;
        private readonly IConfiguration _config;

        public AdminController(MaskanContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        private async Task CreateAdmin()
        {
            var admins = _context.Admins;

            if (admins == null)
            {
                var newAdmin = new Admin
                {
                    AdminEmail = "admin@admin.com",
                    AdminName = "Admin",
                    Password = "123456789"
                };
                await admins.AddAsync(newAdmin);
            }
        }

        private async Task<string> GenerateJwtToken(Admin admin)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier,admin.AdminID.ToString()),
                new Claim(ClaimTypes.Name,admin.AdminName)
            };

            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Admin admin)
        {
            await CreateAdmin();

            if (Response.StatusCode == 400)
            {
                return BadRequest("Enter all of the details");
            }
            var Admin = await _context.Admins.FindAsync(admin.AdminID);

            if (Admin == null)
                return NotFound("Email or password is not correct");

            var result = admin.Password==Admin.Password;

            if (result==true)
            {
                return Ok(new
                {
                    token = GenerateJwtToken(Admin).Result,
                    adminResult =Admin
                });
            }
            return Unauthorized();
        }
    }
}
