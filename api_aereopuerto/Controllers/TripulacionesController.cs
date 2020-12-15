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
    public class TripulacionesController : ControllerBase
    {
        private readonly BaseDatos _context;

        public TripulacionesController(BaseDatos context)
        {
            _context = context;
        }

        // GET: api/Tripulaciones
        [HttpGet]
        public IEnumerable<Tripulacion> GetTripulaciones()
        {
            return _context.Tripulaciones;
        }

        // GET: api/Tripulaciones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripulacion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tripulacion = await _context.Tripulaciones.FindAsync(id);

            if (tripulacion == null)
            {
                return NotFound();
            }

            return Ok(tripulacion);
        }

        // PUT: api/Tripulaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTripulacion([FromRoute] int id, [FromBody] Tripulacion tripulacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tripulacion.TripulacionId)
            {
                return BadRequest();
            }

            _context.Entry(tripulacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripulacionExists(id))
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

        // POST: api/Tripulaciones
        [HttpPost]
        public async Task<IActionResult> PostTripulacion([FromBody] Tripulacion tripulacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tripulaciones.Add(tripulacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTripulacion", new { id = tripulacion.TripulacionId }, tripulacion);
        }

        // DELETE: api/Tripulaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripulacion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tripulacion = await _context.Tripulaciones.FindAsync(id);
            if (tripulacion == null)
            {
                return NotFound();
            }

            _context.Tripulaciones.Remove(tripulacion);
            await _context.SaveChangesAsync();

            return Ok(tripulacion);
        }

        private bool TripulacionExists(int id)
        {
            return _context.Tripulaciones.Any(e => e.TripulacionId == id);
        }
    }
}