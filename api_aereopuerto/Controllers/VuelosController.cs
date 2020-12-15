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
    public class VuelosController : ControllerBase
    {
        private readonly BaseDatos _context;

        public VuelosController(BaseDatos context)
        {
            _context = context;
        }

        // GET: api/Vuelos
        [HttpGet]
        public IEnumerable<Vuelo> GetVuelos()
        {
            return _context.Vuelos;
        }

        // GET: api/Vuelos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVuelo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vuelo = await _context.Vuelos.FindAsync(id);

            if (vuelo == null)
            {
                return NotFound();
            }

            return Ok(vuelo);
        }

        // PUT: api/Vuelos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVuelo([FromRoute] int id, [FromBody] Vuelo vuelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vuelo.VueloId)
            {
                return BadRequest();
            }

            _context.Entry(vuelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VueloExists(id))
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

        // POST: api/Vuelos
        [HttpPost]
        public async Task<IActionResult> PostVuelo([FromBody] Vuelo vuelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vuelos.Add(vuelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVuelo", new { id = vuelo.VueloId }, vuelo);
        }

        // DELETE: api/Vuelos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVuelo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vuelo = await _context.Vuelos.FindAsync(id);
            if (vuelo == null)
            {
                return NotFound();
            }

            _context.Vuelos.Remove(vuelo);
            await _context.SaveChangesAsync();

            return Ok(vuelo);
        }

        private bool VueloExists(int id)
        {
            return _context.Vuelos.Any(e => e.VueloId == id);
        }
    }
}