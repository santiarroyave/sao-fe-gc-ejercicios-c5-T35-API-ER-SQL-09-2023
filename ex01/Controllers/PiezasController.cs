using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ex01.Data;
using ex01.Models;

namespace ex01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiezasController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PiezasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Piezas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pieza>>> Getpiezas()
        {
          if (_context.piezas == null)
          {
              return NotFound();
          }
            return await _context.piezas.ToListAsync();
        }

        // GET: api/Piezas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pieza>> GetPieza(int id)
        {
          if (_context.piezas == null)
          {
              return NotFound();
          }
            var pieza = await _context.piezas.FindAsync(id);

            if (pieza == null)
            {
                return NotFound();
            }

            return pieza;
        }

        // PUT: api/Piezas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPieza(int id, Pieza pieza)
        {
            if (id != pieza.codigo)
            {
                return BadRequest();
            }

            _context.Entry(pieza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiezaExists(id))
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

        // POST: api/Piezas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pieza>> PostPieza(Pieza pieza)
        {
          if (_context.piezas == null)
          {
              return Problem("Entity set 'MyDbContext.piezas'  is null.");
          }
            _context.piezas.Add(pieza);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPieza", new { id = pieza.codigo }, pieza);
        }

        // DELETE: api/Piezas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePieza(int id)
        {
            if (_context.piezas == null)
            {
                return NotFound();
            }
            var pieza = await _context.piezas.FindAsync(id);
            if (pieza == null)
            {
                return NotFound();
            }

            _context.piezas.Remove(pieza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PiezaExists(int id)
        {
            return (_context.piezas?.Any(e => e.codigo == id)).GetValueOrDefault();
        }
    }
}
