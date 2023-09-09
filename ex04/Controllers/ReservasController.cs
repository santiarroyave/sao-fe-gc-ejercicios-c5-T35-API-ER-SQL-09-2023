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
    public class ReservasController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ReservasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> Getreservas()
        {
          if (_context.reservas == null)
          {
              return NotFound();
          }
            return await _context.reservas.ToListAsync();
        }

        // GET: api/Reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(string id)
        {
          if (_context.reservas == null)
          {
              return NotFound();
          }
            var reserva = await _context.reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }

        // PUT: api/Reservas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(string id, Reserva reserva)
        {
            if (id != reserva.fk_numSerie)
            {
                return BadRequest();
            }

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
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

        // POST: api/Reservas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
        {
          if (_context.reservas == null)
          {
              return Problem("Entity set 'MyDbContext.reservas'  is null.");
          }
            _context.reservas.Add(reserva);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReservaExists(reserva.fk_numSerie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReserva", new { id = reserva.fk_numSerie }, reserva);
        }

        // DELETE: api/Reservas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(string id)
        {
            if (_context.reservas == null)
            {
                return NotFound();
            }
            var reserva = await _context.reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaExists(string id)
        {
            return (_context.reservas?.Any(e => e.fk_numSerie == id)).GetValueOrDefault();
        }
    }
}
