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
    public class IitiansController : ControllerBase
    {
        private readonly iit360Context _context;

        public IitiansController(iit360Context context)
        {
            _context = context;
        }

        // GET: api/Iitians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Iitian>>> GetIitian()
        {
            return await _context.Iitian.ToListAsync();
        }

        // GET: api/Iitians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Iitian>> GetIitian(string id)
        {
            var iitian = await _context.Iitian.FindAsync(id);

            if (iitian == null)
            {
                return NotFound();
            }

            return iitian;
        }

        // PUT: api/Iitians/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       /* [HttpPut("{id}")]
        public async Task<IActionResult> PutIitian(string id, Iitian iitian)
        {
            if (id != iitian.IitianMail)
            {
                return BadRequest();
            }

            _context.Entry(iitian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IitianExists(id))
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

        // POST: api/Iitians
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Iitian>> PostIitian(Iitian iitian)
        {
            _context.Iitian.Add(iitian);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IitianExists(iitian.IitianMail))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIitian", new { id = iitian.IitianMail }, iitian);
        }

        // DELETE: api/Iitians/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Iitian>> DeleteIitian(string id)
        {
            var iitian = await _context.Iitian.FindAsync(id);
       
            
            if (iitian == null)
            {
                return NotFound();
            }

            _context.Iitian.Remove(iitian);
            await _context.SaveChangesAsync();

            return iitian;
        }
       */
        private bool IitianExists(string id)
        {
            return _context.Iitian.Any(e => e.IitianMail == id);
        }

        [HttpGet("{id}")]
        public async Task<string> GetSemester(string id)
        {
            var iitian = await _context.Iitian.FindAsync(id);


            if (iitian == null)
            {
                return null;
            }

            return iitian.SemesterCi;
        }
    }
}
