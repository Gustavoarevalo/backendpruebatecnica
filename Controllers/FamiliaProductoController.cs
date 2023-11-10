using DatosPruebaTecnica.Data;
using DatosPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendPruebatecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamiliaProductoController : ControllerBase
    {
        private readonly ILogger<FamiliaProductoController> _logger;

        public readonly DatabaseContext _context;

        public FamiliaProductoController(
            ILogger<FamiliaProductoController> logger,
            DatabaseContext context
        )
        {
            _logger = logger;

            _context = context;
        }

        [HttpGet(Name = "GetFamiliaProductos")]
        public async Task<ActionResult<IEnumerable<FamiliadeProducto>>> GetFamiliaProductos()
        {
            var productos = await _context.FamiliadeProductos.ToListAsync();

            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        [HttpGet("{id}", Name = "GetfamiliaproductoId")]
        public async Task<ActionResult<IEnumerable<FamiliadeProducto>>> GetfamiliaproductoId(int id)
        {
            var obtenerproducto = await _context.FamiliadeProductos.FindAsync(id);

            if (obtenerproducto == null)
            {
                return NotFound();
            }
            return Ok(obtenerproducto);
        }

        [HttpPost("CrearFamiliaProducto")]
        public async Task<ActionResult<IEnumerable<FamiliadeProducto>>> CrearFamiliaProducto(
            FamiliadeProducto familiadeProducto
        )
        {
            var usuarioDB = _context.FamiliadeProductos
                .Where(x => x.Codigo == familiadeProducto.Codigo)
                .FirstOrDefault();

            if (usuarioDB != null)
            {
                return Unauthorized("el codigo ya existe");
            }

            await _context.FamiliadeProductos.AddAsync(familiadeProducto);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarFamilia(
            int id,
            [FromBody] FamiliadeProducto familiadeProducto
        )
        {
        

            var familiadeProductoActual = await _context.FamiliadeProductos.FindAsync(id);

            if (familiadeProductoActual == null)
            {
                return NotFound();
            }

     
            var familiadeProductoDB = _context.FamiliadeProductos
                .Where(x => x.IdFamilia != id && x.Codigo == familiadeProducto.Codigo)
                .FirstOrDefault();

            if (familiadeProductoDB != null)
            {
                return Unauthorized("El codigo ya existe");
            }


            familiadeProductoActual.Codigo = familiadeProducto.Codigo;
            familiadeProductoActual.Nombre = familiadeProducto.Nombre;
            familiadeProductoActual.Activo = familiadeProducto.Activo;

          
            _context.Entry(familiadeProductoActual).State = EntityState.Modified;

        
            await _context.SaveChangesAsync();

         
            return Ok(familiadeProductoActual);
        }

        [HttpDelete("{id}", Name = "EliminaFamilia")]
        public async Task<ActionResult> EliminaFamilia(int id)
        {
            var producto = await _context.FamiliadeProductos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.FamiliadeProductos.Remove(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
