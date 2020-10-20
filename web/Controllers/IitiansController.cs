using IIT360_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IIT360_Web.Controllers
{
    public class IitiansController : Controller
    {
        private readonly iit360Context _context;

        public IitiansController(iit360Context context)
        {
            _context = context;
        }

        // GET: Iitians
        public async Task<IActionResult> Index()
        {
            return View(await _context.Iitian.ToListAsync());
        }

        // GET: Iitians/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iitian = await _context.Iitian
                .FirstOrDefaultAsync(m => m.IitianMail == id);
            if (iitian == null)
            {
                return NotFound();
            }

            return View(iitian);
        }

        // GET: Iitians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Iitians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IitianName,IitianMail,SemesterCi,Connected,LastUpdate")] Iitian iitian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iitian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iitian);
        }

        // GET: Iitians/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iitian = await _context.Iitian.FindAsync(id);
            if (iitian == null)
            {
                return NotFound();
            }
            return View(iitian);
        }

        // POST: Iitians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IitianName,IitianMail,SemesterCi,Connected,LastUpdate")] Iitian iitian)
        {
            if (id != iitian.IitianMail)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iitian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IitianExists(iitian.IitianMail))
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
            return View(iitian);
        }

        // GET: Iitians/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iitian = await _context.Iitian
                .FirstOrDefaultAsync(m => m.IitianMail == id);
            if (iitian == null)
            {
                return NotFound();
            }

            return View(iitian);
        }

        // POST: Iitians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var iitian = await _context.Iitian.FindAsync(id);
            _context.Iitian.Remove(iitian);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IitianExists(string id)
        {
            return _context.Iitian.Any(e => e.IitianMail == id);
        }
    }
}