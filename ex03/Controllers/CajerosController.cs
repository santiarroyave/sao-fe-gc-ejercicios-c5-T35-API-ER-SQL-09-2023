using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ex03.Data;
using ex03.Models;

namespace ex03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajerosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CajerosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Cajeros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cajero>>> Getcajeros()
        {
          if (_context.cajeros == null)
          {
              return NotFound();
          }
            return await _context.cajeros.ToListAsync();
        }

        // GET: api/Cajeros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cajero>> GetCajero(int id)
        {
          if (_context.cajeros == null)
          {
              return NotFound();
          }
            var cajero = await _context.cajeros.FindAsync(id);

            if (cajero == null)
            {
                return NotFound();
            }

            return cajero;
        }

        // PUT: api/Cajeros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCajero(int id, Cajero cajero)
        {
            if (id != cajero.codigo)
            {
                return BadRequest();
            }

            _context.Entry(cajero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CajeroExists(id))
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

        // POST: api/Cajeros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cajero>> PostCajero(Cajero cajero)
        {
          if (_context.cajeros == null)
          {
              return Problem("Entity set 'MyDbContext.cajeros'  is null.");
          }
            _context.cajeros.Add(cajero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCajero", new { id = cajero.codigo }, cajero);
        }

        // DELETE: api/Cajeros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCajero(int id)
        {
            if (_context.cajeros == null)
            {
                return NotFound();
            }
            var cajero = await _context.cajeros.FindAsync(id);
            if (cajero == null)
            {
                return NotFound();
            }

            _context.cajeros.Remove(cajero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CajeroExists(int id)
        {
            return (_context.cajeros?.Any(e => e.codigo == id)).GetValueOrDefault();
        }
    }
}
