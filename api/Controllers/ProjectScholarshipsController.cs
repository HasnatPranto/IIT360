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
    [Route("api/ProjectScholarships/[action]")]
    [ApiController]
    public class ProjectScholarshipsController : ControllerBase
    {
        private readonly iit360Context _context;

        public ProjectScholarshipsController(iit360Context context)
        {
            _context = context;
        }

        // GET: api/ProjectScholarships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectScholarship>>> GetProjectScholarship()
        {
            return await _context.ProjectScholarship.ToListAsync();
        }

        // GET: api/ProjectScholarships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectScholarship>> GetProjectScholarship(int id)
        {
            var projectScholarship = await _context.ProjectScholarship.FindAsync(id);

            if (projectScholarship == null)
            {
                return NotFound();
            }

            return projectScholarship;
        }

        [HttpGet("{fac_code}")]
        public async Task<IActionResult> Individual(string fac_code)
        {
            var proList = _context.ProjectScholarship.Where(s => s.FkFacultyProject == fac_code).ToList();
            return Ok(proList);
        }
        // PUT: api/ProjectScholarships/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       /* [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectScholarship(int id, ProjectScholarship projectScholarship)
        {
            if (id != projectScholarship.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(projectScholarship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectScholarshipExists(id))
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

        // POST: api/ProjectScholarships
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectScholarship>> PostProjectScholarship(ProjectScholarship projectScholarship)
        {
            _context.ProjectScholarship.Add(projectScholarship);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectScholarship", new { id = projectScholarship.ProjectId }, projectScholarship);
        }

        // DELETE: api/ProjectScholarships/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectScholarship>> DeleteProjectScholarship(int id)
        {
            var projectScholarship = await _context.ProjectScholarship.FindAsync(id);
            if (projectScholarship == null)
            {
                return NotFound();
            }

            _context.ProjectScholarship.Remove(projectScholarship);
            await _context.SaveChangesAsync();

            return projectScholarship;
        }
       */
        private bool ProjectScholarshipExists(int id)
        {
            return _context.ProjectScholarship.Any(e => e.ProjectId == id);
        }
    }
}
