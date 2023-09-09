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
    public class Piezas_ProveedoresController : ControllerBase
    {
        private readonly MyDbContext _context;

        public Piezas_ProveedoresController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Piezas_Proveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Piezas_Proveedores>>> Getpiezas_Proveedores()
        {
          if (_context.piezas_Proveedores == null)
          {
              return NotFound();
          }
            return await _context.piezas_Proveedores.ToListAsync();
        }

        // GET: api/Piezas_Proveedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Piezas_Proveedores>> GetPiezas_Proveedores(int id)
        {
          if (_context.piezas_Proveedores == null)
          {
              return NotFound();
          }
            var piezas_Proveedores = await _context.piezas_Proveedores.FindAsync(id);

            if (piezas_Proveedores == null)
            {
                return NotFound();
            }

            return piezas_Proveedores;
        }

        // PUT: api/Piezas_Proveedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiezas_Proveedores(int id, Piezas_Proveedores piezas_Proveedores)
        {
            if (id != piezas_Proveedores.fk_codigoPieza)
            {
                return BadRequest();
            }

            _context.Entry(piezas_Proveedores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Piezas_ProveedoresExists(id))
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

        // POST: api/Piezas_Proveedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Piezas_Proveedores>> PostPiezas_Proveedores(Piezas_Proveedores piezas_Proveedores)
        {
          if (_context.piezas_Proveedores == null)
          {
              return Problem("Entity set 'MyDbContext.piezas_Proveedores'  is null.");
          }
            _context.piezas_Proveedores.Add(piezas_Proveedores);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Piezas_ProveedoresExists(piezas_Proveedores.fk_codigoPieza))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPiezas_Proveedores", new { id = piezas_Proveedores.fk_codigoPieza }, piezas_Proveedores);
        }

        // DELETE: api/Piezas_Proveedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePiezas_Proveedores(int id)
        {
            if (_context.piezas_Proveedores == null)
            {
                return NotFound();
            }
            var piezas_Proveedores = await _context.piezas_Proveedores.FindAsync(id);
            if (piezas_Proveedores == null)
            {
                return NotFound();
            }

            _context.piezas_Proveedores.Remove(piezas_Proveedores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Piezas_ProveedoresExists(int id)
        {
            return (_context.piezas_Proveedores?.Any(e => e.fk_codigoPieza == id)).GetValueOrDefault();
        }
    }
}
