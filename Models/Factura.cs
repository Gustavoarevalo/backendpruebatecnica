using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatosPruebaTecnica.Models
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }

        public int? NumerodeFactura { get; set; }

        [Required]
        public string? Ruc { get; set; }

        [Required]
        public string? Razonsocial { get; set; }

        [Required]
        public decimal Subtotal { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public decimal IGV { get; set; }

        [Required]
        public decimal Total { get; set; }

        public ICollection<DetalleFactura> DetalleFactura { get; set; } =
            new List<DetalleFactura>();

        public override string ToString()
        {
            return $"IdFactura: {IdFactura}, NumerodeFactura: {NumerodeFactura}, Ruc: {Ruc}, Razonsocial: {Razonsocial}, Subtotal: {Subtotal}, IGV: {IGV}, Total: {Total}  detallefactura:{DetalleFactura}";
        }
    }
}

/*
   [Key]
        public int IdFactura { get; set; }

        public int? NumerodeFactura { get; set; }

        [Required]
        public string? Ruc { get; set; }

        [Required]
        public string? Razonsocial { get; set; }

        [Required]
        public int Subtotal { get; set; }

        public DateTime FechaCreacion { get; set; }

        [Required]
        public int IGV { get; set; }

        [Required]
        public int Total { get; set; }

        public ICollection<DetalleFactura> DetalleFacturas { get; set; } =
            new List<DetalleFactura>(); */
