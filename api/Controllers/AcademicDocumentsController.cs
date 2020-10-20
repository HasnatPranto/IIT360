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
    public class AcademicDocumentsController : ControllerBase
    {
        private readonly iit360Context _context;

        public AcademicDocumentsController(iit360Context context)
        {
            _context = context;
        }

        // GET: api/AcademicDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicDocument>>> GetAcademicDocument()
        {
            return await _context.AcademicDocument.ToListAsync();
        }

        // GET: api/AcademicDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicDocument>> GetAcademicDocument(int id)
        {
            var academicDocument = await _context.AcademicDocument.FindAsync(id);

            if (academicDocument == null)
            {
                return NotFound();
            }

            return academicDocument;
        }

        // PUT: api/AcademicDocuments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       /* [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicDocument(int id, AcademicDocument academicDocument)
        {
            if (id != academicDocument.AcDocId)
            {
                return BadRequest();
            }

            _context.Entry(academicDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicDocumentExists(id))
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

        // POST: api/AcademicDocuments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AcademicDocument>> PostAcademicDocument(AcademicDocument academicDocument)
        {
            _context.AcademicDocument.Add(academicDocument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcademicDocument", new { id = academicDocument.AcDocId }, academicDocument);
        }

        // DELETE: api/AcademicDocuments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AcademicDocument>> DeleteAcademicDocument(int id)
        {
            var academicDocument = await _context.AcademicDocument.FindAsync(id);
            if (academicDocument == null)
            {
                return NotFound();
            }

            _context.AcademicDocument.Remove(academicDocument);
            await _context.SaveChangesAsync();

            return academicDocument;
        }*/

        private bool AcademicDocumentExists(int id)
        {
            return _context.AcademicDocument.Any(e => e.AcDocId == id);
        }
    }
}
