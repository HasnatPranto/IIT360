using IIT360_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IIT360_Web.Controllers
{
    public class AimObjectivesController : Controller
    {
        private readonly iit360Context _context;

        public AimObjectivesController(iit360Context context)
        {
            _context = context;
        }

        // GET: AimObjectives
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ano.ToListAsync());
        }

        // GET: AimObjectives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ano = await _context.Ano.FirstOrDefaultAsync(m => m.AnoId == id);
            if (ano == null)
            {
                return NotFound();
            }

            return View(ano);
        }

        // GET: AimObjectives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AimObjectives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnoId,Aim")] Ano ano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ano);
        }

        // GET: AimObjectives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ano = await _context.Ano.FindAsync(id);
            if (ano == null)
            {
                return NotFound();
            }
            return View(ano);
        }

        // POST: AimObjectives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnoId,Aim")] Ano ano)
        {
            if (id != ano.AnoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnoExists(ano.AnoId))
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
            return View(ano);
        }

        // GET: AimObjectives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ano = await _context.Ano
                .FirstOrDefaultAsync(m => m.AnoId == id);
            if (ano == null)
            {
                return NotFound();
            }

            return View(ano);
        }

        // POST: AimObjectives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ano = await _context.Ano.FindAsync(id);
            _context.Ano.Remove(ano);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnoExists(int id)
        {
            return _context.Ano.Any(e => e.AnoId == id);
        }
    }
}