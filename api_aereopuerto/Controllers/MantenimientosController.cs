using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_aereopuerto.Modelos;

namespace api_aereopuerto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientosController : ControllerBase
    {
        private readonly BaseDatos _context;

        public MantenimientosController(BaseDatos context)
        {
            _context = context;
        }

        // GET: api/Mantenimientos
        [HttpGet]
        public IEnumerable<Mantenimiento> GetMantenimientos()
        {
            return _context.Mantenimientos;
        }

        // GET: api/Mantenimientos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMantenimiento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mantenimiento = await _context.Mantenimientos.FindAsync(id);

            if (mantenimiento == null)
            {
                return NotFound();
            }

            return Ok(mantenimiento);
        }

        // PUT: api/Mantenimientos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMantenimiento([FromRoute] int id, [FromBody] Mantenimiento mantenimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mantenimiento.MantenimientoId)
            {
                return BadRequest();
            }

            _context.Entry(mantenimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MantenimientoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Mantenimientos
        [HttpPost]
        public async Task<IActionResult> PostMantenimiento([FromBody] Mantenimiento mantenimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Mantenimientos.Add(mantenimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMantenimiento", new { id = mantenimiento.MantenimientoId }, mantenimiento);
        }

        // DELETE: api/Mantenimientos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMantenimiento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mantenimiento = await _context.Mantenimientos.FindAsync(id);
            if (mantenimiento == null)
            {
                return NotFound();
            }

            _context.Mantenimientos.Remove(mantenimiento);
            await _context.SaveChangesAsync();

            return Ok(mantenimiento);
        }

        private bool MantenimientoExists(int id)
        {
            return _context.Mantenimientos.Any(e => e.MantenimientoId == id);
        }
    }
}