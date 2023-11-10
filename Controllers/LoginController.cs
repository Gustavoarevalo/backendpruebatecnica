using DatosPruebaTecnica.Data;
using Microsoft.AspNetCore.Mvc;
using DatosPruebaTecnica.Models;
using BackendPruebatecnica.Services;

namespace DatosPruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LoginController(DatabaseContext context)
        {
            this._context = context;
        }

        [HttpPost("registro")]
        public IActionResult CrearUsuario([FromBody] Login usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Invalid user data");
            }

            var usuarioDB = _context.Logins.Where(x => x.Correo == usuario.Correo).FirstOrDefault();

            if (usuarioDB != null)
            {
                return Unauthorized("Correo ya Existe");
            }

            var contraseniaEncriptada = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasenia);
            usuario.Contrasenia = contraseniaEncriptada;

            _context.Logins.Add(usuario);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Invalid user data");
            }

            var usuarioDB = _context.Logins.Where(x => x.Correo == usuario.Correo).FirstOrDefault();

            if (usuarioDB == null)
            {
                return Unauthorized("Invalid credentials");
            }

            if (usuarioDB.Bloqueado != false)
            {
                return Unauthorized("usuario bloqueado");
            }

            var contraseniaBD = usuarioDB.Contrasenia;
            var contraseniaCorrecta = BCrypt.Net.BCrypt.Verify(
                usuario.Contrasenia,
                contraseniaBD
            );

            if (!contraseniaCorrecta)
            {
                usuarioDB.Intentos++;


                int numerodeintentos = 3;

                if (usuarioDB.Intentos >= numerodeintentos)
                {
                    usuarioDB.Bloqueado = true;
                }

         
                _context.SaveChanges();

                if (usuarioDB.Bloqueado != false)
                {
                    return Unauthorized("usuario bloqueado");
                }

                return Unauthorized("Invalid credentials");
            }

            usuarioDB.Intentos = 0;

            _context.SaveChanges();

            return Ok(usuarioDB.Nombre);
        }
    }
}
