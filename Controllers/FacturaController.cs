using DatosPruebaTecnica.Data;
using DatosPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BackendPruebatecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly ILogger<FacturaController> _logger;

        public readonly DatabaseContext _context;

        public FacturaController(ILogger<FacturaController> logger, DatabaseContext context)
        {
            _logger = logger;

            _context = context;
        }

        [HttpGet(Name = "GetFacturas")]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas()
        {
            var facturas = await _context.Facturas.Include(p => p.DetalleFactura).ToListAsync();

            if (facturas == null)
            {
                return NotFound();
            }

            var response = facturas.Select(
                p =>
                    new
                    {
                        IdFactura = p.IdFactura,
                        NumerodeFactura = p.NumerodeFactura,
                        Subtotal = p.Subtotal,
                        Razonsocial = p.Razonsocial,
                        Ruc = p.Ruc,
                        IGV = p.IGV,
                        FechaCreacion = p.FechaCreacion,
                        DetalleFactura = p.DetalleFactura
                            .Select(
                                d =>
                                    new
                                    {
                                        IdItem = d.IdItem,
                                        Codigo = d.Codigo,
                                        Nombre = d.Nombre,
                                        Precio = d.Precio,
                                        Cantidad = d.Cantidad,
                                        Subtotal = d.Subtotal,
                                    }
                            )
                            .ToList()
                    }
            );

            return Ok(response);
        }

        [HttpPost(Name = "GuardarFactura")]
        public async Task<IActionResult> GuardarFactura([FromBody] Factura factura)
        {
            string facturaData = JsonSerializer.Serialize(factura);
            _logger.LogInformation($"Datos de factura recibidos: {facturaData}");

            int? ultimoNumerodeFactura = _context.Facturas.Max(f => f.NumerodeFactura);

            factura.NumerodeFactura =
                (ultimoNumerodeFactura.HasValue) ? ultimoNumerodeFactura + 1 : 1;

            await _context.Facturas.AddAsync(factura);
            await _context.SaveChangesAsync();
            int facturaId = factura.IdFactura;

            return Ok(facturaId);
        }
    }
}
