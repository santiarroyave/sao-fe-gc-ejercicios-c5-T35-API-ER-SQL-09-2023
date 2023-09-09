using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ex02.Data;
using ex02.Models;

namespace ex02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProyectosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Proyectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> Getproyecto()
        {
          if (_context.proyecto == null)
          {
              return NotFound();
          }
            return await _context.proyecto.ToListAsync();
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> GetProyecto(string id)
        {
          if (_context.proyecto == null)
          {
              return NotFound();
          }
            var proyecto = await _context.proyecto.FindAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return proyecto;
        }

        // PUT: api/Proyectos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyecto(string id, Proyecto proyecto)
        {
            if (id != proyecto.id)
            {
                return BadRequest();
            }

            _context.Entry(proyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoExists(id))
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

        // POST: api/Proyectos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proyecto>> PostProyecto(Proyecto proyecto)
        {
          if (_context.proyecto == null)
          {
              return Problem("Entity set 'MyDbContext.proyecto'  is null.");
          }
            _context.proyecto.Add(proyecto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProyectoExists(proyecto.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProyecto", new { id = proyecto.id }, proyecto);
        }

        // DELETE: api/Proyectos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyecto(string id)
        {
            if (_context.proyecto == null)
            {
                return NotFound();
            }
            var proyecto = await _context.proyecto.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }

            _context.proyecto.Remove(proyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProyectoExists(string id)
        {
            return (_context.proyecto?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
