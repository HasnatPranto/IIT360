using IIT360_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IIT360_Web.Controllers
{
    public class ResearchesController : Controller
    {
        private readonly iit360Context _context;

        public ResearchesController(iit360Context context)
        {
            _context = context;
        }

        // GET: Researches
        public async Task<IActionResult> Index()
        {
            var iit360Context = _context.Research.Include(r => r.FkFacultyResearchNavigation);
            return View(await iit360Context.ToListAsync());
        }

        // GET: Researches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research = await _context.Research
                .Include(r => r.FkFacultyResearchNavigation)
                .FirstOrDefaultAsync(m => m.ResearchId == id);
            if (research == null)
            {
                return NotFound();
            }

            return View(research);
        }

        // GET: Researches/Create
        public IActionResult Create()
        {
            ViewData["FkFacultyResearch"] = new SelectList(_context.Faculty, "FacultyId", "FacultyId");
            return View();
        }

        // POST: Researches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResearchId,Title,Description,FkFacultyResearch")] Research research)
        {
            if (ModelState.IsValid)
            {
                _context.Add(research);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkFacultyResearch"] = new SelectList(_context.Faculty, "FacultyId", "FacultyId", research.FkFacultyResearch);
            return View(research);
        }

        // GET: Researches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research = await _context.Research.FindAsync(id);
            if (research == null)
            {
                return NotFound();
            }
            ViewData["FkFacultyResearch"] = new SelectList(_context.Faculty, "FacultyId", "FacultyId", research.FkFacultyResearch);
            return View(research);
        }

        // POST: Researches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResearchId,Title,Description,FkFacultyResearch")] Research research)
        {
            if (id != research.ResearchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(research);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResearchExists(research.ResearchId))
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
            ViewData["FkFacultyResearch"] = new SelectList(_context.Faculty, "FacultyId", "FacultyId", research.FkFacultyResearch);
            return View(research);
        }

        // GET: Researches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research = await _context.Research
                .Include(r => r.FkFacultyResearchNavigation)
                .FirstOrDefaultAsync(m => m.ResearchId == id);
            if (research == null)
            {
                return NotFound();
            }

            return View(research);
        }

        // POST: Researches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var research = await _context.Research.FindAsync(id);
            _context.Research.Remove(research);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResearchExists(int id)
        {
            return _context.Research.Any(e => e.ResearchId == id);
        }
    }
}