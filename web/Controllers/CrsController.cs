using IIT360_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IIT360_Web.Controllers
{
    public class CrsController : Controller
    {
        private readonly iit360Context _context;

        public CrsController(iit360Context context)
        {
            _context = context;
        }

        // GET: Crs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cr.ToListAsync());
        }

        // GET: Crs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cr = await _context.Cr
                .FirstOrDefaultAsync(m => m.CrMailId == id);
            if (cr == null)
            {
                return NotFound();
            }

            return View(cr);
        }

        // GET: Crs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CrMailId,Semester")] Cr cr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cr);
        }

        // GET: Crs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cr = await _context.Cr.FindAsync(id);
            if (cr == null)
            {
                return NotFound();
            }
            return View(cr);
        }

        // POST: Crs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CrMailId,Semester")] Cr cr)
        {
            if (id != cr.CrMailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrExists(cr.CrMailId))
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
            return View(cr);
        }

        // GET: Crs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cr = await _context.Cr
                .FirstOrDefaultAsync(m => m.CrMailId == id);
            if (cr == null)
            {
                return NotFound();
            }

            return View(cr);
        }

        // POST: Crs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cr = await _context.Cr.FindAsync(id);
            _context.Cr.Remove(cr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrExists(string id)
        {
            return _context.Cr.Any(e => e.CrMailId == id);
        }
    }
}