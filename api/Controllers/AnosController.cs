using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IIT360_api.Models;

namespace IIT360_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnosController : ControllerBase
    {
        private readonly iit360Context _context;

        public AnosController(iit360Context context)
        {
            _context = context;
        }

        // GET: api/Anos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ano>>> GetAno()
        {
            return await _context.Ano.ToListAsync();
        }

        // GET: api/Anos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ano>> GetAno(int id)
        {
            var ano = await _context.Ano.FindAsync(id);

            if (ano == null)
            {
                return NotFound();
            }

            return ano;
        }

        // PUT: api/Anos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
      /*  [HttpPut("{id}")]
        public async Task<IActionResult> PutAno(int id, Ano ano)
        {
            if (id != ano.AnoId)
            {
                return BadRequest();
            }

            _context.Entry(ano).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnoExists(id))
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

        // POST: api/Anos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ano>> PostAno(Ano ano)
        {
            _context.Ano.Add(ano);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAno", new { id = ano.AnoId }, ano);
        }

        // DELETE: api/Anos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ano>> DeleteAno(int id)
        {
            var ano = await _context.Ano.FindAsync(id);
            if (ano == null)
            {
                return NotFound();
            }

            _context.Ano.Remove(ano);
            await _context.SaveChangesAsync();

            return ano;
        }
      */
        private bool AnoExists(int id)
        {
            return _context.Ano.Any(e => e.AnoId == id);
        }
    }
}
