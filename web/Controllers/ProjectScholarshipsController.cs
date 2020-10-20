using IIT360_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IIT360_Web.Controllers
{
    public class ProjectScholarshipsController : Controller
    {
        private readonly iit360Context _context;

        public ProjectScholarshipsController(iit360Context context)
        {
            _context = context;
        }

        // GET: ProjectScholarships
        public async Task<IActionResult> Index()
        {
            var iit360Context = _context.ProjectScholarship.Include(p => p.FkFacultyProjectNavigation);
            return View(await iit360Context.ToListAsync());
        }

        // GET: ProjectScholarships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectScholarship = await _context.ProjectScholarship
                .Include(p => p.FkFacultyProjectNavigation)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (projectScholarship == null)
            {
                return NotFound();
            }

            return View(projectScholarship);
        }

        // GET: ProjectScholarships/Create
        public IActionResult Create()
        {
            ViewData["FkFacultyProject"] = new SelectList(_context.Faculty, "FacultyId", "FacultyId");
            return View();
        }

        // POST: ProjectScholarships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProScholType,Title,Description,FkFacultyProject")] ProjectScholarship projectScholarship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectScholarship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkFacultyProject"] = new SelectList(_context.Faculty, "FacultyId", "FacultyId", projectScholarship.FkFacultyProject);
            return View(projectScholarship);
        }

        // GET: ProjectScholarships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectScholarship = await _context.ProjectScholarship.FindAsync(id);
            if (projectScholarship == null)
            {
                return NotFound();
            }
            ViewData["FkFacultyProject"] = new SelectList(_context.Faculty, "FacultyId", "FacultyId", projectScholarship.FkFacultyProject);
            return View(projectScholarship);
        }

        // POST: ProjectScholarships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProScholType,Title,Description,FkFacultyProject")] ProjectScholarship projectScholarship)
        {
            if (id != projectScholarship.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectScholarship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectScholarshipExists(projectScholarship.ProjectId))
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
            ViewData["FkFacultyProject"] = new SelectList(_context.Faculty, "FacultyId", "FacultyId", projectScholarship.FkFacultyProject);
            return View(projectScholarship);
        }

        // GET: ProjectScholarships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectScholarship = await _context.ProjectScholarship
                .Include(p => p.FkFacultyProjectNavigation)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (projectScholarship == null)
            {
                return NotFound();
            }

            return View(projectScholarship);
        }

        // POST: ProjectScholarships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectScholarship = await _context.ProjectScholarship.FindAsync(id);
            _context.ProjectScholarship.Remove(projectScholarship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectScholarshipExists(int id)
        {
            return _context.ProjectScholarship.Any(e => e.ProjectId == id);
        }
    }
}