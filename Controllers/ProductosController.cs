using DatosPruebaTecnica.Data;
using DatosPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BackendPruebatecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;

        public readonly DatabaseContext _context;

        public ProductosController(ILogger<ProductosController> logger, DatabaseContext context)
        {
            _logger = logger;

            _context = context;
        }

        /*

        [HttpGet(Name = "Getproductos")]
        public async Task<ActionResult<IEnumerable<Producto>>> Getproductos()
        {
            var productos = await _context.Productos.ToListAsync();

            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }
*/
        [HttpGet(Name = "Getproductos")]
        public async Task<ActionResult<IEnumerable<Producto>>> Getproductos()
        {
            var productos = await _context.Productos
                .Include(p => p.FamiliadeProducto)
                .ToListAsync();

            if (productos == null)
            {
                return NotFound();
            }

            var response = productos.Select(
                p =>
                    new
                    {
                        IdProducto = p.IdProducto,
                        Nombre = p.Nombre,
                        Codigo = p.Codigo,
                        Precio = p.Precio,
                        Stock = p.Stock,
                        Activo = p.Activo,
                        FamiliaProducto = new
                        {
                            IdFamilia = p.FamiliadeProducto.IdFamilia,
                            Nombre = p.FamiliadeProducto.Nombre,
                        }
                    }
            );

            return Ok(response);
        }

        [HttpPost(Name = "CrearProducto")]
        public async Task<IActionResult> CrearProducto(Producto producto)
        {
            try
            {
                var productoDB = _context.Productos
                    .Where(x => x.Codigo == producto.Codigo)
                    .FirstOrDefault();

                if (productoDB != null)
                {
                    return BadRequest("El código ya existe.");
                }

                var familiaDeProducto = _context.FamiliadeProductos.FirstOrDefault(
                    f => f.IdFamilia == producto.IdFamilia
                );

                if (familiaDeProducto == null)
                {
                    return NotFound("La familia de productos no existe.");
                }

                producto.FamiliadeProducto = familiaDeProducto;

                _context.Attach(producto);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPut("{id}", Name = "ActualizarProducto")]
        public async Task<ActionResult<Producto>> ActualizarProducto(
            int id,
            [FromBody] Producto producto
        )
        {
            var productoActual = await _context.Productos
                .Include(p => p.FamiliadeProducto)
                .FirstOrDefaultAsync(p => p.IdProducto == id);

            if (productoActual == null)
            {
                return NotFound("Producto no encontrado.");
            }

            // Verificar si el código se ha cambiado y ya existe
            if (productoActual.Codigo != producto.Codigo)
            {
                var productoExistente = await _context.Productos.FirstOrDefaultAsync(
                    p => p.Codigo == producto.Codigo
                );

                if (productoExistente != null)
                {
                    return Conflict("El código ya existe para otro producto.");
                }
            }

            // Verificar si la familia de productos existe
            var familiaDeProducto = await _context.FamiliadeProductos.FirstOrDefaultAsync(
                f => f.IdFamilia == producto.IdFamilia
            );

            if (familiaDeProducto == null)
            {
                return NotFound("La familia de productos no existe.");
            }

            productoActual.Nombre = producto.Nombre;
            productoActual.Precio = producto.Precio;
            productoActual.Codigo = producto.Codigo;
            productoActual.Stock = producto.Stock;
            productoActual.Activo = producto.Activo;
            productoActual.IdFamilia = producto.IdFamilia;
            productoActual.FamiliadeProducto = familiaDeProducto;

            try
            {
                _context.Entry(productoActual).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("Se ha producido un conflicto al actualizar el producto.");
            }

            return Ok();
        }

        [HttpDelete("{id}", Name = "EliminarProducto")]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
