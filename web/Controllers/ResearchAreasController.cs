using IIT360_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IIT360_Web.Controllers
{
    public class ResearchAreasController : Controller
    {
        private readonly iit360Context _context;

        public ResearchAreasController(iit360Context context)
        {
            _context = context;
        }

        // GET: ResearchAreas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Researcharea.ToListAsync());
        }

        // GET: ResearchAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researcharea = await _context.Researcharea
                .FirstOrDefaultAsync(m => m.ResearchAreaId == id);
            if (researcharea == null)
            {
                return NotFound();
            }

            return View(researcharea);
        }

        // GET: ResearchAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResearchAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResearchAreaId,FieldName,AreaDescription")] Researcharea researcharea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(researcharea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(researcharea);
        }

        // GET: ResearchAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researcharea = await _context.Researcharea.FindAsync(id);
            if (researcharea == null)
            {
                return NotFound();
            }
            return View(researcharea);
        }

        // POST: ResearchAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResearchAreaId,FieldName,AreaDescription")] Researcharea researcharea)
        {
            if (id != researcharea.ResearchAreaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(researcharea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResearchareaExists(researcharea.ResearchAreaId))
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
            return View(researcharea);
        }

        // GET: ResearchAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researcharea = await _context.Researcharea
                .FirstOrDefaultAsync(m => m.ResearchAreaId == id);
            if (researcharea == null)
            {
                return NotFound();
            }

            return View(researcharea);
        }

        // POST: ResearchAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var researcharea = await _context.Researcharea.FindAsync(id);
            _context.Researcharea.Remove(researcharea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResearchareaExists(int id)
        {
            return _context.Researcharea.Any(e => e.ResearchAreaId == id);
        }
    }
}