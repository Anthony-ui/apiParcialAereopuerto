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
    public class PilotosController : ControllerBase
    {
        private readonly BaseDatos _context;

        public PilotosController(BaseDatos context)
        {
            _context = context;
        }

        // GET: api/Pilotos
        [HttpGet]
        public IEnumerable<Piloto> GetPilotos()
        {
            return _context.Pilotos;
        }

        // GET: api/Pilotos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPiloto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var piloto = await _context.Pilotos.FindAsync(id);

            if (piloto == null)
            {
                return NotFound();
            }

            return Ok(piloto);
        }

        // PUT: api/Pilotos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiloto([FromRoute] int id, [FromBody] Piloto piloto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != piloto.PilotoId)
            {
                return BadRequest();
            }

            _context.Entry(piloto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PilotoExists(id))
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

        // POST: api/Pilotos
        [HttpPost]
        public async Task<IActionResult> PostPiloto([FromBody] Piloto piloto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pilotos.Add(piloto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPiloto", new { id = piloto.PilotoId }, piloto);
        }

        // DELETE: api/Pilotos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePiloto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var piloto = await _context.Pilotos.FindAsync(id);
            if (piloto == null)
            {
                return NotFound();
            }

            _context.Pilotos.Remove(piloto);
            await _context.SaveChangesAsync();

            return Ok(piloto);
        }

        private bool PilotoExists(int id)
        {
            return _context.Pilotos.Any(e => e.PilotoId == id);
        }
    }
}