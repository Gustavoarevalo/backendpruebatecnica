using DatosPruebaTecnica.Data;
using DatosPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BackendPruebatecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleFacturaController : ControllerBase
    {
        private readonly ILogger<DetalleFacturaController> _logger;
        private readonly DatabaseContext _context;

        public DetalleFacturaController(
            ILogger<DetalleFacturaController> logger,
            DatabaseContext context
        )
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost(Name = "GuardarDetalleFactura")]
        public async Task<IActionResult> GuardarDetalleFactura(
            [FromQuery] int Idproducto,
            [FromBody] DetalleFactura oDetalleFactura
        )
        {
            Console.WriteLine(oDetalleFactura);
            var producto = await _context.Productos.FindAsync(Idproducto);

            if (producto != null)
            {
                producto.Stock -= oDetalleFactura.Cantidad;
            }

            await _context.SaveChangesAsync();

            var factura = _context.Facturas.FirstOrDefault(
                f => f.IdFactura == oDetalleFactura.IdFactura
            );

            oDetalleFactura.Factura = factura;

            _context.DetalleFacturas.Attach(oDetalleFactura);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
