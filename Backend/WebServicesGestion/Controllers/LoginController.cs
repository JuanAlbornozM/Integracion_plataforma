using DB;
using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebServicesGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly GestionContext _context;

        public LoginController(GestionContext context)
        {
            _context = context;
        }

        [HttpPost("byCredentials")]
        [ActionName("PostByCredentials")]
        public async Task<ActionResult<Usuario>> PostByCredentials([FromBody] LoginUsuario model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarios = await _context.Usuarios
                .Where(u => u.Email == model.Email && u.Password == model.Password)
                .FirstOrDefaultAsync();

            if (usuarios == null)
            {
                return NotFound();
            }

            var token = GenerateJwtToken(usuarios.UsuarioID);

            return Ok(new { Usuario = usuarios, Token = token });
        }

        private string GenerateJwtToken(int userId)
        {
            var securityKey = GenerateSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Test-Issuer",
                audience: "test-app",
                claims: new[] { new Claim(ClaimTypes.Name, userId.ToString()) },
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private SymmetricSecurityKey GenerateSecurityKey()
        {
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var keyBytes = new byte[32];
                randomNumberGenerator.GetBytes(keyBytes);
                return new SymmetricSecurityKey(keyBytes);
            }
        }
    }
}
