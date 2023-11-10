using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatosPruebaTecnica.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string? Codigo { get; set; }

        public string? Nombre { get; set; }

        public int Precio { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; }

        public int IdFamilia { get; set; }

        [ForeignKey("IdFamilia")]
        public FamiliadeProducto FamiliadeProducto { get; set; } = null!;
    }
}
