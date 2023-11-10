using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatosPruebaTecnica.Models
{
    public class FamiliadeProducto
    {
        [Key]
        public int IdFamilia { get; set; }

        [Column(TypeName = "varchar(15)")]
        [Required]
        public string? Codigo { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public bool Activo { get; set; } = true;

        public DateTime? FechaCreacion { get; set; }

        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
