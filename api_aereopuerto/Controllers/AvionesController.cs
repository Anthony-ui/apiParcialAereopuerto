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
    public class AvionesController : ControllerBase
    {
        private readonly BaseDatos _context;

        public AvionesController(BaseDatos context)
        {
            _context = context;
        }

        // GET: api/Aviones
        [HttpGet]
        public IEnumerable<Avion> GetAviones()
        {
            return _context.Aviones;
        }

        // GET: api/Aviones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAvion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var avion = await _context.Aviones.FindAsync(id);

            if (avion == null)
            {
                return NotFound();
            }

            return Ok(avion);
        }

        // PUT: api/Aviones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvion([FromRoute] int id, [FromBody] Avion avion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != avion.AvionId)
            {
                return BadRequest();
            }

            _context.Entry(avion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvionExists(id))
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

        // POST: api/Aviones
        [HttpPost]
        public async Task<IActionResult> PostAvion([FromBody] Avion avion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Aviones.Add(avion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvion", new { id = avion.AvionId }, avion);
        }

        // DELETE: api/Aviones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var avion = await _context.Aviones.FindAsync(id);
            if (avion == null)
            {
                return NotFound();
            }

            _context.Aviones.Remove(avion);
            await _context.SaveChangesAsync();

            return Ok(avion);
        }

        private bool AvionExists(int id)
        {
            return _context.Aviones.Any(e => e.AvionId == id);
        }


        [HttpGet("repetido")]
        public string acceder(string codigo)
        {
            string res;

            if (_context.Aviones.Where(x=>x.Codigo==codigo).Count() > 0)
            {
                res = "ok";
            }
            else
            {
                res = "error";
            }

            return res;
        }
    }
}