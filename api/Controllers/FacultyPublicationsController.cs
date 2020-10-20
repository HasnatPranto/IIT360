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
    public class FacultyPublicationsController : ControllerBase
    {
        private readonly iit360Context _context;

        public FacultyPublicationsController(iit360Context context)
        {
            _context = context;
        }

        // GET: api/FacultyPublications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacultyPublication>>> GetFacultyPublication()
        {
            return await _context.FacultyPublication.ToListAsync();
        }

        // GET: api/FacultyPublications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacultyPublication>> GetFacultyPublication(int id)
        {
            var facultyPublication = await _context.FacultyPublication.FindAsync(id);

            if (facultyPublication == null)
            {
                return NotFound();
            }

            return facultyPublication;
        }

        // PUT: api/FacultyPublications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
      /*  [HttpPut("{id}")]
        public async Task<IActionResult> PutFacultyPublication(int id, FacultyPublication facultyPublication)
        {
            if (id != facultyPublication.FacPubId)
            {
                return BadRequest();
            }

            _context.Entry(facultyPublication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultyPublicationExists(id))
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

        // POST: api/FacultyPublications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FacultyPublication>> PostFacultyPublication(FacultyPublication facultyPublication)
        {
            _context.FacultyPublication.Add(facultyPublication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacultyPublication", new { id = facultyPublication.FacPubId }, facultyPublication);
        }

        // DELETE: api/FacultyPublications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FacultyPublication>> DeleteFacultyPublication(int id)
        {
            var facultyPublication = await _context.FacultyPublication.FindAsync(id);
            if (facultyPublication == null)
            {
                return NotFound();
            }

            _context.FacultyPublication.Remove(facultyPublication);
            await _context.SaveChangesAsync();

            return facultyPublication;
        }
      */
        private bool FacultyPublicationExists(int id)
        {
            return _context.FacultyPublication.Any(e => e.FacPubId == id);
        }
    }
}
