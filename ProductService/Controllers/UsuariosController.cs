using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.DataBack;
using ProductService.Dtos;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] UsuarioRegisterDto usuarioRegisterDto)
        {
            try
            {
                Console.WriteLine("Iniciando registro de usuario...");
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (string.IsNullOrWhiteSpace(usuarioRegisterDto.Nombre)
                    || string.IsNullOrWhiteSpace(usuarioRegisterDto.Email)
                    || string.IsNullOrWhiteSpace(usuarioRegisterDto.ContrasenaHash)
                    || string.IsNullOrWhiteSpace(usuarioRegisterDto.TipoUsuario))
                {
                    return BadRequest(new { message = "Todos los campos son obligatorios." });
                }

                var existeUsuario = await _context.Usuarios
                    .AnyAsync(u => u.Email == usuarioRegisterDto.Email);
                if (existeUsuario)
                    return Conflict(new { message = "El email ya está registrado." });

                _context.Usuarios.Add(new Models.Usuario
                {
                    Nombre = usuarioRegisterDto.Nombre,
                    Email = usuarioRegisterDto.Email,
                    ContrasenaHash = usuarioRegisterDto.ContrasenaHash, //hashear la contraseña
                    TipoUsuario = usuarioRegisterDto.TipoUsuario == "Rama" ? "Rama" : "TROPA"
                });
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al registrar el usuario.", error = ex.Message });
            }
            return Ok();
        }
    }
}
