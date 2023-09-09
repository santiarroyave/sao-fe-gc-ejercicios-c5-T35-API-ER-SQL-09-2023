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
    public class Cientifico_ProyectoController : ControllerBase
    {
        private readonly MyDbContext _context;

        public Cientifico_ProyectoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Cientifico_Proyecto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cientifico_Proyecto>>> Getcientifico_Proyectos()
        {
          if (_context.cientifico_Proyectos == null)
          {
              return NotFound();
          }
            return await _context.cientifico_Proyectos.ToListAsync();
        }

        // GET: api/Cientifico_Proyecto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cientifico_Proyecto>> GetCientifico_Proyecto(string id)
        {
          if (_context.cientifico_Proyectos == null)
          {
              return NotFound();
          }
            var cientifico_Proyecto = await _context.cientifico_Proyectos.FindAsync(id);

            if (cientifico_Proyecto == null)
            {
                return NotFound();
            }

            return cientifico_Proyecto;
        }

        // PUT: api/Cientifico_Proyecto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCientifico_Proyecto(string id, Cientifico_Proyecto cientifico_Proyecto)
        {
            if (id != cientifico_Proyecto.fk_proyecto_id)
            {
                return BadRequest();
            }

            _context.Entry(cientifico_Proyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cientifico_ProyectoExists(id))
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

        // POST: api/Cientifico_Proyecto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cientifico_Proyecto>> PostCientifico_Proyecto(Cientifico_Proyecto cientifico_Proyecto)
        {
          if (_context.cientifico_Proyectos == null)
          {
              return Problem("Entity set 'MyDbContext.cientifico_Proyectos'  is null.");
          }
            _context.cientifico_Proyectos.Add(cientifico_Proyecto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Cientifico_ProyectoExists(cientifico_Proyecto.fk_proyecto_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCientifico_Proyecto", new { id = cientifico_Proyecto.fk_proyecto_id }, cientifico_Proyecto);
        }

        // DELETE: api/Cientifico_Proyecto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCientifico_Proyecto(string id)
        {
            if (_context.cientifico_Proyectos == null)
            {
                return NotFound();
            }
            var cientifico_Proyecto = await _context.cientifico_Proyectos.FindAsync(id);
            if (cientifico_Proyecto == null)
            {
                return NotFound();
            }

            _context.cientifico_Proyectos.Remove(cientifico_Proyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Cientifico_ProyectoExists(string id)
        {
            return (_context.cientifico_Proyectos?.Any(e => e.fk_proyecto_id == id)).GetValueOrDefault();
        }
    }
}
