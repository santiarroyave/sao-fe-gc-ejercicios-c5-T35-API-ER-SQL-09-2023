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
    public class Maquinas_RegistradorasController : ControllerBase
    {
        private readonly MyDbContext _context;

        public Maquinas_RegistradorasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Maquinas_Registradoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maquina_Registradora>>> GetmaquinasRegistradoras()
        {
          if (_context.maquinasRegistradoras == null)
          {
              return NotFound();
          }
            return await _context.maquinasRegistradoras.ToListAsync();
        }

        // GET: api/Maquinas_Registradoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maquina_Registradora>> GetMaquina_Registradora(int id)
        {
          if (_context.maquinasRegistradoras == null)
          {
              return NotFound();
          }
            var maquina_Registradora = await _context.maquinasRegistradoras.FindAsync(id);

            if (maquina_Registradora == null)
            {
                return NotFound();
            }

            return maquina_Registradora;
        }

        // PUT: api/Maquinas_Registradoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaquina_Registradora(int id, Maquina_Registradora maquina_Registradora)
        {
            if (id != maquina_Registradora.codigo)
            {
                return BadRequest();
            }

            _context.Entry(maquina_Registradora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Maquina_RegistradoraExists(id))
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

        // POST: api/Maquinas_Registradoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Maquina_Registradora>> PostMaquina_Registradora(Maquina_Registradora maquina_Registradora)
        {
          if (_context.maquinasRegistradoras == null)
          {
              return Problem("Entity set 'MyDbContext.maquinasRegistradoras'  is null.");
          }
            _context.maquinasRegistradoras.Add(maquina_Registradora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaquina_Registradora", new { id = maquina_Registradora.codigo }, maquina_Registradora);
        }

        // DELETE: api/Maquinas_Registradoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaquina_Registradora(int id)
        {
            if (_context.maquinasRegistradoras == null)
            {
                return NotFound();
            }
            var maquina_Registradora = await _context.maquinasRegistradoras.FindAsync(id);
            if (maquina_Registradora == null)
            {
                return NotFound();
            }

            _context.maquinasRegistradoras.Remove(maquina_Registradora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Maquina_RegistradoraExists(int id)
        {
            return (_context.maquinasRegistradoras?.Any(e => e.codigo == id)).GetValueOrDefault();
        }
    }
}
