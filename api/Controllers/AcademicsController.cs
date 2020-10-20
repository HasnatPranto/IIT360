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
    [Route("api/Academics/[action]")]
    [ApiController]
    public class AcademicsController : ControllerBase
    {
        private readonly iit360Context _context;

        public AcademicsController(iit360Context context)
        {
            _context = context;
        }

        // GET: api/Academics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Academic>>> GetAcademic()
        {
            return await _context.Academic.ToListAsync();
        }

        // GET: api/Academics/TP
        [HttpGet("{section}")]
        public async Task<IActionResult> GetAcademic(string section)
        {
            var academic = _context.Academic.Where(s=>s.AcademicSection==section);

            if (academic == null)
            {
                return NotFound();
            }

            return Ok(academic);
        }

        // PUT: api/Academics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
      /*  [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademic(int id, Academic academic)
        {
            if (id != academic.AcademicId)
            {
                return BadRequest();
            }

            _context.Entry(academic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicExists(id))
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

        // POST: api/Academics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Academic>> PostAcademic(Academic academic)
        {
            _context.Academic.Add(academic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcademic", new { id = academic.AcademicId }, academic);
        }

        // DELETE: api/Academics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Academic>> DeleteAcademic(int id)
        {
            var academic = await _context.Academic.FindAsync(id);
            if (academic == null)
            {
                return NotFound();
            }

            _context.Academic.Remove(academic);
            await _context.SaveChangesAsync();

            return academic;
        }
      */
        private bool AcademicExists(int id)
        {
            return _context.Academic.Any(e => e.AcademicId == id);
        }
    }
}
