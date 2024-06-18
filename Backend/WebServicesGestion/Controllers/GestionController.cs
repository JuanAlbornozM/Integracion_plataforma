using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DB;
using Microsoft.EntityFrameworkCore;

namespace WebServicesGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionController : ControllerBase
    {
        private readonly GestionContext _gestionDbContext;
        public GestionController(GestionContext gestionUsuarioDbContext)
        {
            _gestionDbContext = gestionUsuarioDbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return _gestionDbContext.Usuarios;
        }
        [HttpGet("ByUsuario")]
        [ActionName("GetById")]
        public async Task<ActionResult<Usuario>> GetById(int id_usuario)
        {
            var usuarios = await _gestionDbContext.Usuarios.FindAsync(id_usuario);
            if (usuarios == null)
            {
                return NotFound(new { Message = $"Usuario con ID {id_usuario} no encontrado." });
            }
            return usuarios;
        }
        [HttpGet("byEmail")]
        [ActionName("GetByEmail")]
        public async Task<ActionResult<Usuario>> GetByEmail(string email)
        {
            var usuarios = await _gestionDbContext.Usuarios.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (usuarios == null)
            {
                return NotFound(new { Message = $"Usuario con email {email} no encontrado." });
            }
            return usuarios;
        }
        [HttpPost("CreateUser")]
        [ActionName("Create")]
        public async Task<ActionResult> Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usu = await _gestionDbContext.Usuarios.Where(u => u.Email == usuario.Email).FirstOrDefaultAsync();
            if (usu == null)
            {
                await _gestionDbContext.Usuarios.AddAsync(usuario);
                await _gestionDbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return Conflict("Usuario ya existe");
            }

        }
        [HttpPut("UpdateUser")]
        [ActionName("Update")]
        public async Task<ActionResult> Update(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usu = await _gestionDbContext.Usuarios.Where(u => u.UsuarioID == usuario.UsuarioID).FirstOrDefaultAsync();
            if (usu != null)
            {
                _gestionDbContext.Usuarios.Update(usuario);
                await _gestionDbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return Conflict($"Usuario con ID {usuario.UsuarioID} no existe");
            }
            
        }
        [HttpDelete("{id_usuario}")]
        public async Task<ActionResult> Delete(int id_usuario)
        {
            var usuarios = await _gestionDbContext.Usuarios.FindAsync(id_usuario);
            if (usuarios != null)
            {
                _gestionDbContext.Usuarios.Remove(usuarios);
                await _gestionDbContext.SaveChangesAsync();
                return Ok();
            } else
            {
                return Conflict($"Usuario con ID {id_usuario} no existe");
            }

        }
    }
}
