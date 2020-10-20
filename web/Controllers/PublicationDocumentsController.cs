using IIT360_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IIT360_Web.Controllers
{
    public class PublicationDocumentsController : Controller
    {
        private readonly iit360Context _context;

        public PublicationDocumentsController(iit360Context context)
        {
            _context = context;
        }

        // GET: PublicationDocuments
        public async Task<IActionResult> Index()
        {
            var iit360Context = _context.PublicationDocument.Include(p => p.FkDocumentPubdocNavigation).Include(p => p.FkPublicationPubdocNavigation);
            return View(await iit360Context.ToListAsync());
        }

        // GET: PublicationDocuments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicationDocument = await _context.PublicationDocument
                .Include(p => p.FkDocumentPubdocNavigation)
                .Include(p => p.FkPublicationPubdocNavigation)
                .FirstOrDefaultAsync(m => m.PubDocId == id);
            if (publicationDocument == null)
            {
                return NotFound();
            }

            return View(publicationDocument);
        }

        // GET: PublicationDocuments/Create
        public IActionResult Create()
        {
            ViewData["FkDocumentPubdoc"] = new SelectList(_context.Document, "DocumentId", "PdfName");
            ViewData["FkPublicationPubdoc"] = new SelectList(_context.Publication, "PublicationId", "PublicationId");
            return View();
        }

        // POST: PublicationDocuments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PubDocId,FkPublicationPubdoc,FkDocumentPubdoc")] PublicationDocument publicationDocument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicationDocument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkDocumentPubdoc"] = new SelectList(_context.Document, "DocumentId", "PdfName", publicationDocument.FkDocumentPubdoc);
            ViewData["FkPublicationPubdoc"] = new SelectList(_context.Publication, "PublicationId", "PublicationId", publicationDocument.FkPublicationPubdoc);
            return View(publicationDocument);
        }

        // GET: PublicationDocuments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicationDocument = await _context.PublicationDocument.FindAsync(id);
            if (publicationDocument == null)
            {
                return NotFound();
            }
            ViewData["FkDocumentPubdoc"] = new SelectList(_context.Document, "DocumentId", "PdfName", publicationDocument.FkDocumentPubdoc);
            ViewData["FkPublicationPubdoc"] = new SelectList(_context.Publication, "PublicationId", "PublicationId", publicationDocument.FkPublicationPubdoc);
            return View(publicationDocument);
        }

        // POST: PublicationDocuments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PubDocId,FkPublicationPubdoc,FkDocumentPubdoc")] PublicationDocument publicationDocument)
        {
            if (id != publicationDocument.PubDocId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicationDocument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicationDocumentExists(publicationDocument.PubDocId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkDocumentPubdoc"] = new SelectList(_context.Document, "DocumentId", "PdfName", publicationDocument.FkDocumentPubdoc);
            ViewData["FkPublicationPubdoc"] = new SelectList(_context.Publication, "PublicationId", "PublicationId", publicationDocument.FkPublicationPubdoc);
            return View(publicationDocument);
        }

        // GET: PublicationDocuments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicationDocument = await _context.PublicationDocument
                .Include(p => p.FkDocumentPubdocNavigation)
                .Include(p => p.FkPublicationPubdocNavigation)
                .FirstOrDefaultAsync(m => m.PubDocId == id);
            if (publicationDocument == null)
            {
                return NotFound();
            }

            return View(publicationDocument);
        }

        // POST: PublicationDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicationDocument = await _context.PublicationDocument.FindAsync(id);
            _context.PublicationDocument.Remove(publicationDocument);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicationDocumentExists(int id)
        {
            return _context.PublicationDocument.Any(e => e.PubDocId == id);
        }
    }
}