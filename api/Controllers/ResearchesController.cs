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
    [Route("api/Researches/[action]")]
    [ApiController]
    public class ResearchesController : ControllerBase
    {
        private readonly iit360Context _context;

        public ResearchesController(iit360Context context)
        {
            _context = context;
        }

        // GET: api/Researches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Research>>> GetResearch()
        {
            return await _context.Research.ToListAsync();
        }

        // GET: api/Researches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Research>> GetResearch(int id)
        {
            var research = await _context.Research.FindAsync(id);

            if (research == null)
            {
                return NotFound();
            }

            return research;
        }
        [HttpGet("{fac_code}")]
        public async Task<IActionResult> FacultyResearch(string fac_code) {

            var r = _context.Research.Where(s => s.FkFacultyResearch == fac_code).ToList();
            return Ok(r);
        }

        // PUT: api/Researches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutResearch(int id, Research research)
        {
            if (id != research.ResearchId)
            {
                return BadRequest();
            }

            _context.Entry(research).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearchExists(id))
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

        // POST: api/Researches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Research>> PostResearch(Research research)
        {
            _context.Research.Add(research);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResearch", new { id = research.ResearchId }, research);
        }

        // DELETE: api/Researches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Research>> DeleteResearch(int id)
        {
            var research = await _context.Research.FindAsync(id);
            if (research == null)
            {
                return NotFound();
            }

            _context.Research.Remove(research);
            await _context.SaveChangesAsync();

            return research;
        }
        */
        private bool ResearchExists(int id)
        {
            return _context.Research.Any(e => e.ResearchId == id);
        }
    }
}
