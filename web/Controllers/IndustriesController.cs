using IIT360_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IIT360_Web.Controllers
{
    public class IndustriesController : Controller
    {
        private readonly iit360Context _context;

        public IndustriesController(iit360Context context)
        {
            _context = context;
        }

        // GET: Industries
        public async Task<IActionResult> Index()
        {
            // var iit360Context = _context.Industry.Include(i => i.IndIconNavigation);
            //return View(await iit360Context.ToListAsync());

            return View(await _context.Industry.ToListAsync());
        }

        // GET: Industries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industry = await _context.Industry
                .Include(i => i.IndIconNavigation)
                .FirstOrDefaultAsync(m => m.IndustryId == id);
            if (industry == null)
            {
                return NotFound();
            }

            return View(industry);
        }

        // GET: Industries/Create
        public IActionResult Create()
        {
            ViewData["IndIcon"] = new SelectList(_context.Image, "ImageId", "ImgName");
            return View();
        }

        // POST: Industries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IndustryId,Featured,IndustryName,IndIcon,IndLink")] Industry industry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(industry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IndIcon"] = new SelectList(_context.Image, "ImageId", "ImgName", industry.IndIcon);
            return View(industry);
        }

        // GET: Industries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industry = await _context.Industry.FindAsync(id);
            if (industry == null)
            {
                return NotFound();
            }
            ViewData["IndIcon"] = new SelectList(_context.Image, "ImageId", "ImgName", industry.IndIcon);
            return View(industry);
        }

        // POST: Industries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IndustryId,Featured,IndustryName,IndIcon,IndLink")] Industry industry)
        {
            if (id != industry.IndustryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(industry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndustryExists(industry.IndustryId))
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
            ViewData["IndIcon"] = new SelectList(_context.Image, "ImageId", "ImgName", industry.IndIcon);
            return View(industry);
        }

        // GET: Industries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industry = await _context.Industry
                .Include(i => i.IndIconNavigation)
                .FirstOrDefaultAsync(m => m.IndustryId == id);
            if (industry == null)
            {
                return NotFound();
            }

            return View(industry);
        }

        // POST: Industries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var industry = await _context.Industry.FindAsync(id);
            _context.Industry.Remove(industry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndustryExists(int id)
        {
            return _context.Industry.Any(e => e.IndustryId == id);
        }
    }
}