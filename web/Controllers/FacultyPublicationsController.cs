using IIT360_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IIT360_Web.Controllers
{
    public class FacultyPublicationsController : Controller
    {
        private readonly iit360Context _context;

        public FacultyPublicationsController(iit360Context context)
        {
            _context = context;
        }

        // GET: FacultyPublications
        public async Task<IActionResult> Index()
        {
            var iit360Context = _context.FacultyPublication.Include(f => f.FkFacultyFacpubNavigation).Include(f => f.FkPublicationFacpubNavigation);
            return View(await iit360Context.ToListAsync());
        }

        // GET: FacultyPublications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultyPublication = await _context.FacultyPublication
                .Include(f => f.FkFacultyFacpubNavigation)
                .Include(f => f.FkPublicationFacpubNavigation)
                .FirstOrDefaultAsync(m => m.FacPubId == id);
            if (facultyPublication == null)
            {
                return NotFound();
            }

            return View(facultyPublication);
        }

        // GET: FacultyPublications/Create
        public IActionResult Create()
        {
            ViewData["FkFacultyFacpub"] = new SelectList(_context.Faculty, "FacultyId", "FacultyId");
            ViewData["FkPublicationFacpub"] = new SelectList(_context.Publication, "PublicationId", "PublicationId");
            return View();
        }

        // POST: FacultyPublications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacPubId,FkFacultyFacpub,FkPublicationFacpub")] FacultyPublication facultyPublication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultyPublication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkFacultyFacpub"] = new SelectList(_context.Faculty, "FacultyId", "FacultyId", facultyPublication.FkFacultyFacpub);
            ViewData["FkPublicationFacpub"] = new SelectList(_context.Publication, "PublicationId", "PublicationId", facultyPublication.FkPublicationFacpub);
            return View(facultyPublication);
        }

        // GET: FacultyPublications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultyPublication = await _context.FacultyPublication.FindAsync(id);
            if (facultyPublication == null)
            {
                return NotFound();
            }
            ViewData["FkFacultyFacpub"] = new SelectList(_context.Faculty, "FacultyId", "FacultyId", facultyPublication.FkFacultyFacpub);
            ViewData["FkPublicationFacpub"] = new SelectList(_context.Publication, "PublicationId", "PublicationId", facultyPublication.FkPublicationFacpub);
            return View(facultyPublication);
        }

        // POST: FacultyPublications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacPubId,FkFacultyFacpub,FkPublicationFacpub")] FacultyPublication facultyPublication)
        {
            if (id != facultyPublication.FacPubId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultyPublication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyPublicationExists(facultyPublication.FacPubId))
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
            ViewData["FkFacultyFacpub"] = new SelectList(_context.Faculty, "FacultyId", "FacultyId", facultyPublication.FkFacultyFacpub);
            ViewData["FkPublicationFacpub"] = new SelectList(_context.Publication, "PublicationId", "PublicationId", facultyPublication.FkPublicationFacpub);
            return View(facultyPublication);
        }

        // GET: FacultyPublications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultyPublication = await _context.FacultyPublication
                .Include(f => f.FkFacultyFacpubNavigation)
                .Include(f => f.FkPublicationFacpubNavigation)
                .FirstOrDefaultAsync(m => m.FacPubId == id);
            if (facultyPublication == null)
            {
                return NotFound();
            }

            return View(facultyPublication);
        }

        // POST: FacultyPublications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facultyPublication = await _context.FacultyPublication.FindAsync(id);
            _context.FacultyPublication.Remove(facultyPublication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultyPublicationExists(int id)
        {
            return _context.FacultyPublication.Any(e => e.FacPubId == id);
        }
    }
}