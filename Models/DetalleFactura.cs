using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatosPruebaTecnica.Models
{
    public class DetalleFactura
    {
        [Key]
        public int IdItem { get; set; }

        public string? Codigo { get; set; }

        public string? Nombre { get; set; }

        public decimal? Precio { get; set; }

        public int Cantidad { get; set; }

        public decimal? Subtotal { get; set; }

        //  public int? Idproducto { get; set; } //esta variable solo esta para obtener los datos que llegan del frontend y despues elimina la catidad del producto

        public int? IdFactura { get; set; }

        [ForeignKey("IdFactura")]
        public Factura? Factura { get; set; } = null!;
    }
}

/*

       [Key]
        public int IdItem { get; set; }

        [Required]
        public string? CodigoProducto { get; set; }

        [Required]
        public string? NombreProducto { get; set; }

        [Required]
        public int Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public int? Subtotal { get; set; }

        public int IdFactura { get; set; }

        [ForeignKey("IdFactura")]
        public Factura Factura { get; set; } = null!;

        */
