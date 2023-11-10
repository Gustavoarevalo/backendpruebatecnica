using System.ComponentModel.DataAnnotations;

namespace DatosPruebaTecnica.Models
{
    public class Login
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        [Required]
        public string? Correo { get; set; }

        [Required]
        public string? Contrasenia { get; set; }

        public int? Intentos { get; set; } = 0;

        public bool? Bloqueado { get; set; } = false;
    }
}
