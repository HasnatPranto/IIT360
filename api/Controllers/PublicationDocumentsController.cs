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
    public class PublicationDocumentsController : ControllerBase
    {
        private readonly iit360Context _context;

        public PublicationDocumentsController(iit360Context context)
        {
            _context = context;
        }

        // GET: api/PublicationDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicationDocument>>> GetPublicationDocument()
        {
            return await _context.PublicationDocument.ToListAsync();
        }

        // GET: api/PublicationDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicationDocument>> GetPublicationDocument(int id)
        {
            var publicationDocument = await _context.PublicationDocument.FindAsync(id);

            if (publicationDocument == null)
            {
                return NotFound();
            }

            return publicationDocument;
        }

        // PUT: api/PublicationDocuments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutPublicationDocument(int id, PublicationDocument publicationDocument)
        {
            if (id != publicationDocument.PubDocId)
            {
                return BadRequest();
            }

            _context.Entry(publicationDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationDocumentExists(id))
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

        // POST: api/PublicationDocuments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PublicationDocument>> PostPublicationDocument(PublicationDocument publicationDocument)
        {
            _context.PublicationDocument.Add(publicationDocument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicationDocument", new { id = publicationDocument.PubDocId }, publicationDocument);
        }

        // DELETE: api/PublicationDocuments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicationDocument>> DeletePublicationDocument(int id)
        {
            var publicationDocument = await _context.PublicationDocument.FindAsync(id);
            if (publicationDocument == null)
            {
                return NotFound();
            }

            _context.PublicationDocument.Remove(publicationDocument);
            await _context.SaveChangesAsync();

            return publicationDocument;
        }*/

        private bool PublicationDocumentExists(int id)
        {
            return _context.PublicationDocument.Any(e => e.PubDocId == id);
        }
    }
}
