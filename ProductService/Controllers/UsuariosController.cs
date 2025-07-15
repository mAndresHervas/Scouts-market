using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.DataBack;
using ProductService.Dtos;
using ProductService.Models;

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
            public async Task<IActionResult> Register(UsuarioRegisterDto usuarioRegisterDto)
            {
               Console.WriteLine("Registro de usuario iniciado...");
            // 1. Validaciones (¿email ya registrado?)
            // 2. Hasheo de contraseña
            // 3. Guardar en la DB
            // 4. Retornar 200 o 400 según el caso

            return Ok(); // placeholder
            }
        }
}
