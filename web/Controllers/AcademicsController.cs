using IIT360_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IIT360_Web.Controllers
{
    public class AcademicsController : Controller
    {
        private readonly iit360Context _context;

        public AcademicsController(iit360Context context)
        {
            _context = context;
        }

        // GET: Academics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Academic.ToListAsync());
        }

        // GET: Academics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academic = await _context.Academic
                .FirstOrDefaultAsync(m => m.AcademicId == id);
            if (academic == null)
            {
                return NotFound();
            }

            return View(academic);
        }

        // GET: Academics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Academics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcademicId,AcademicSection,Programs,AcademicInfo,AcademicAdmission")] Academic academic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academic);
        }

        // GET: Academics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academic = await _context.Academic.FindAsync(id);
            if (academic == null)
            {
                return NotFound();
            }
            return View(academic);
        }

        // POST: Academics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcademicId,AcademicSection,Programs,AcademicInfo,AcademicAdmission")] Academic academic)
        {
            if (id != academic.AcademicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicExists(academic.AcademicId))
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
            return View(academic);
        }

        // GET: Academics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academic = await _context.Academic
                .FirstOrDefaultAsync(m => m.AcademicId == id);
            if (academic == null)
            {
                return NotFound();
            }

            return View(academic);
        }

        // POST: Academics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academic = await _context.Academic.FindAsync(id);
            _context.Academic.Remove(academic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicExists(int id)
        {
            return _context.Academic.Any(e => e.AcademicId == id);
        }
    }
}