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
    public class ResearchareasController : ControllerBase
    {
        private readonly iit360Context _context;

        public ResearchareasController(iit360Context context)
        {
            _context = context;
        }

        // GET: api/Researchareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Researcharea>>> GetResearcharea()
        {
            return await _context.Researcharea.ToListAsync();
        }

        // GET: api/Researchareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Researcharea>> GetResearcharea(int id)
        {
            var researcharea = await _context.Researcharea.FindAsync(id);

            if (researcharea == null)
            {
                return NotFound();
            }

            return researcharea;
        }

        // PUT: api/Researchareas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutResearcharea(int id, Researcharea researcharea)
        {
            if (id != researcharea.ResearchAreaId)
            {
                return BadRequest();
            }

            _context.Entry(researcharea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearchareaExists(id))
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

        // POST: api/Researchareas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Researcharea>> PostResearcharea(Researcharea researcharea)
        {
            _context.Researcharea.Add(researcharea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResearcharea", new { id = researcharea.ResearchAreaId }, researcharea);
        }

        // DELETE: api/Researchareas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Researcharea>> DeleteResearcharea(int id)
        {
            var researcharea = await _context.Researcharea.FindAsync(id);
            if (researcharea == null)
            {
                return NotFound();
            }

            _context.Researcharea.Remove(researcharea);
            await _context.SaveChangesAsync();

            return researcharea;
        }
        */
        private bool ResearchareaExists(int id)
        {
            return _context.Researcharea.Any(e => e.ResearchAreaId == id);
        }
    }
}
