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
    public class MiembrosController : ControllerBase
    {
        private readonly BaseDatos _context;

        public MiembrosController(BaseDatos context)
        {
            _context = context;
        }

        // GET: api/Miembros
        [HttpGet]
        public IEnumerable<Miembro> GetMiembros()
        {
            return _context.Miembros;
        }

        // GET: api/Miembros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMiembro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var miembro = await _context.Miembros.FindAsync(id);

            if (miembro == null)
            {
                return NotFound();
            }

            return Ok(miembro);
        }

        // PUT: api/Miembros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiembro([FromRoute] int id, [FromBody] Miembro miembro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != miembro.MiembroId)
            {
                return BadRequest();
            }

            _context.Entry(miembro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiembroExists(id))
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

        // POST: api/Miembros
        [HttpPost]
        public async Task<IActionResult> PostMiembro([FromBody] Miembro miembro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Miembros.Add(miembro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMiembro", new { id = miembro.MiembroId }, miembro);
        }

        // DELETE: api/Miembros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiembro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var miembro = await _context.Miembros.FindAsync(id);
            if (miembro == null)
            {
                return NotFound();
            }

            _context.Miembros.Remove(miembro);
            await _context.SaveChangesAsync();

            return Ok(miembro);
        }

        private bool MiembroExists(int id)
        {
            return _context.Miembros.Any(e => e.MiembroId == id);
        }
    }
}