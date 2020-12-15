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
    public class BasesController : ControllerBase
    {
        private readonly BaseDatos _context;

        public BasesController(BaseDatos context)
        {
            _context = context;
        }

        // GET: api/Bases
        [HttpGet]
        public IEnumerable<Base> GetBases()
        {
            return _context.Bases;
        }

        // GET: api/Bases/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @base = await _context.Bases.FindAsync(id);

            if (@base == null)
            {
                return NotFound();
            }

            return Ok(@base);
        }

        // PUT: api/Bases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBase([FromRoute] int id, [FromBody] Base @base)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @base.BaseId)
            {
                return BadRequest();
            }

            _context.Entry(@base).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseExists(id))
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

        // POST: api/Bases
        [HttpPost]
        public async Task<IActionResult> PostBase([FromBody] Base @base)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bases.Add(@base);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBase", new { id = @base.BaseId }, @base);
        }

        // DELETE: api/Bases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @base = await _context.Bases.FindAsync(id);
            if (@base == null)
            {
                return NotFound();
            }

            _context.Bases.Remove(@base);
            await _context.SaveChangesAsync();

            return Ok(@base);
        }

        private bool BaseExists(int id)
        {
            return _context.Bases.Any(e => e.BaseId == id);
        }
    }
}