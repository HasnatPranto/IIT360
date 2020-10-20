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
    public class CrsController : ControllerBase
    {
        private readonly iit360Context _context;

        public CrsController(iit360Context context)
        {
            _context = context;
        }

        // GET: api/Crs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cr>>> GetCr()
        {
            return await _context.Cr.ToListAsync();
        }

        // GET: api/Crs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cr>> GetCr(string id)
        {
            var cr = await _context.Cr.FindAsync(id);

            if (cr == null)
            {
                return NotFound();
            }

            return cr;
        }

        // PUT: api/Crs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutCr(string id, Cr cr)
        {
            if (id != cr.CrMailId)
            {
                return BadRequest();
            }

            _context.Entry(cr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrExists(id))
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

        // POST: api/Crs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cr>> PostCr(Cr cr)
        {
            _context.Cr.Add(cr);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CrExists(cr.CrMailId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCr", new { id = cr.CrMailId }, cr);
        }

        // DELETE: api/Crs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cr>> DeleteCr(string id)
        {
            var cr = await _context.Cr.FindAsync(id);
            if (cr == null)
            {
                return NotFound();
            }

            _context.Cr.Remove(cr);
            await _context.SaveChangesAsync();

            return cr;
        }
        */
        private bool CrExists(string id)
        {
            return _context.Cr.Any(e => e.CrMailId == id);
        }
    }
}
