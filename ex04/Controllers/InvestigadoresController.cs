using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ex04.Data;
using ex04.Models;

namespace ex04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestigadoresController : ControllerBase
    {
        private readonly MyDbContext _context;

        public InvestigadoresController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Investigadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investigador>>> Getinvestigadores()
        {
          if (_context.investigadores == null)
          {
              return NotFound();
          }
            return await _context.investigadores.ToListAsync();
        }

        // GET: api/Investigadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Investigador>> GetInvestigador(string id)
        {
          if (_context.investigadores == null)
          {
              return NotFound();
          }
            var investigador = await _context.investigadores.FindAsync(id);

            if (investigador == null)
            {
                return NotFound();
            }

            return investigador;
        }

        // PUT: api/Investigadores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestigador(string id, Investigador investigador)
        {
            if (id != investigador.dni)
            {
                return BadRequest();
            }

            _context.Entry(investigador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestigadorExists(id))
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

        // POST: api/Investigadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Investigador>> PostInvestigador(Investigador investigador)
        {
          if (_context.investigadores == null)
          {
              return Problem("Entity set 'MyDbContext.investigadores'  is null.");
          }
            _context.investigadores.Add(investigador);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InvestigadorExists(investigador.dni))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInvestigador", new { id = investigador.dni }, investigador);
        }

        // DELETE: api/Investigadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestigador(string id)
        {
            if (_context.investigadores == null)
            {
                return NotFound();
            }
            var investigador = await _context.investigadores.FindAsync(id);
            if (investigador == null)
            {
                return NotFound();
            }

            _context.investigadores.Remove(investigador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvestigadorExists(string id)
        {
            return (_context.investigadores?.Any(e => e.dni == id)).GetValueOrDefault();
        }
    }
}
