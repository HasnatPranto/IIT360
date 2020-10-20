using IIT360_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IIT360_Web.Controllers
{
    public class AcademicDocumentsController : Controller
    {
        private readonly iit360Context _context;

        public AcademicDocumentsController(iit360Context context)
        {
            _context = context;
        }

        // GET: AcademicDocuments
        public async Task<IActionResult> Index()
        {
            var iit360Context = _context.AcademicDocument.Include(a => a.FkAcademicAcdocNavigation).Include(a => a.FkDocumentAcdocNavigation);
            return View(await iit360Context.ToListAsync());
        }

        // GET: AcademicDocuments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicDocument = await _context.AcademicDocument
                .Include(a => a.FkAcademicAcdocNavigation)
                .Include(a => a.FkDocumentAcdocNavigation)
                .FirstOrDefaultAsync(m => m.AcDocId == id);
            if (academicDocument == null)
            {
                return NotFound();
            }

            return View(academicDocument);
        }

        // GET: AcademicDocuments/Create
        public IActionResult Create()
        {
            ViewData["FkAcademicAcdoc"] = new SelectList(_context.Academic, "AcademicId", "AcademicAdmission");
            ViewData["FkDocumentAcdoc"] = new SelectList(_context.Document, "DocumentId", "PdfName");
            return View();
        }

        // POST: AcademicDocuments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcDocId,Note,FkAcademicAcdoc,FkDocumentAcdoc")] AcademicDocument academicDocument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicDocument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkAcademicAcdoc"] = new SelectList(_context.Academic, "AcademicId", "AcademicAdmission", academicDocument.FkAcademicAcdoc);
            ViewData["FkDocumentAcdoc"] = new SelectList(_context.Document, "DocumentId", "PdfName", academicDocument.FkDocumentAcdoc);
            return View(academicDocument);
        }

        // GET: AcademicDocuments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicDocument = await _context.AcademicDocument.FindAsync(id);
            if (academicDocument == null)
            {
                return NotFound();
            }
            ViewData["FkAcademicAcdoc"] = new SelectList(_context.Academic, "AcademicId", "AcademicAdmission", academicDocument.FkAcademicAcdoc);
            ViewData["FkDocumentAcdoc"] = new SelectList(_context.Document, "DocumentId", "PdfName", academicDocument.FkDocumentAcdoc);
            return View(academicDocument);
        }

        // POST: AcademicDocuments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcDocId,Note,FkAcademicAcdoc,FkDocumentAcdoc")] AcademicDocument academicDocument)
        {
            if (id != academicDocument.AcDocId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicDocument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicDocumentExists(academicDocument.AcDocId))
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
            ViewData["FkAcademicAcdoc"] = new SelectList(_context.Academic, "AcademicId", "AcademicAdmission", academicDocument.FkAcademicAcdoc);
            ViewData["FkDocumentAcdoc"] = new SelectList(_context.Document, "DocumentId", "PdfName", academicDocument.FkDocumentAcdoc);
            return View(academicDocument);
        }

        // GET: AcademicDocuments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicDocument = await _context.AcademicDocument
                .Include(a => a.FkAcademicAcdocNavigation)
                .Include(a => a.FkDocumentAcdocNavigation)
                .FirstOrDefaultAsync(m => m.AcDocId == id);
            if (academicDocument == null)
            {
                return NotFound();
            }

            return View(academicDocument);
        }

        // POST: AcademicDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicDocument = await _context.AcademicDocument.FindAsync(id);
            _context.AcademicDocument.Remove(academicDocument);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicDocumentExists(int id)
        {
            return _context.AcademicDocument.Any(e => e.AcDocId == id);
        }
    }
}