using IIT360_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IIT360_Web.Controllers
{
    public class EventImagesController : Controller
    {
        private readonly iit360Context _context;

        public EventImagesController(iit360Context context)
        {
            _context = context;
        }

        // GET: EventImages
        public async Task<IActionResult> Index()
        {
            var iit360Context = _context.EventImage.Include(e => e.FkEventEvemgeNavigation).Include(e => e.FkImageEvemgeNavigation);
            return View(await iit360Context.ToListAsync());
        }

        // GET: EventImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventImage = await _context.EventImage
                .Include(e => e.FkEventEvemgeNavigation)
                .Include(e => e.FkImageEvemgeNavigation)
                .FirstOrDefaultAsync(m => m.IdeventImage == id);
            if (eventImage == null)
            {
                return NotFound();
            }

            return View(eventImage);
        }

        // GET: EventImages/Create
        public IActionResult Create()
        {
            ViewData["FkEventEvemge"] = new SelectList(_context.Event, "EventId", "EventId");
            ViewData["FkImageEvemge"] = new SelectList(_context.Image, "ImageId", "ImgName");
            return View();
        }

        // POST: EventImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdeventImage,Caption,FkEventEvemge,FkImageEvemge")] EventImage eventImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkEventEvemge"] = new SelectList(_context.Event, "EventId", "EventId", eventImage.FkEventEvemge);
            ViewData["FkImageEvemge"] = new SelectList(_context.Image, "ImageId", "ImgName", eventImage.FkImageEvemge);
            return View(eventImage);
        }

        // GET: EventImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventImage = await _context.EventImage.FindAsync(id);
            if (eventImage == null)
            {
                return NotFound();
            }
            ViewData["FkEventEvemge"] = new SelectList(_context.Event, "EventId", "EventId", eventImage.FkEventEvemge);
            ViewData["FkImageEvemge"] = new SelectList(_context.Image, "ImageId", "ImgName", eventImage.FkImageEvemge);
            return View(eventImage);
        }

        // POST: EventImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdeventImage,Caption,FkEventEvemge,FkImageEvemge")] EventImage eventImage)
        {
            if (id != eventImage.IdeventImage)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventImageExists(eventImage.IdeventImage))
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
            ViewData["FkEventEvemge"] = new SelectList(_context.Event, "EventId", "EventId", eventImage.FkEventEvemge);
            ViewData["FkImageEvemge"] = new SelectList(_context.Image, "ImageId", "ImgName", eventImage.FkImageEvemge);
            return View(eventImage);
        }

        // GET: EventImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventImage = await _context.EventImage
                .Include(e => e.FkEventEvemgeNavigation)
                .Include(e => e.FkImageEvemgeNavigation)
                .FirstOrDefaultAsync(m => m.IdeventImage == id);
            if (eventImage == null)
            {
                return NotFound();
            }

            return View(eventImage);
        }

        // POST: EventImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventImage = await _context.EventImage.FindAsync(id);
            _context.EventImage.Remove(eventImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventImageExists(int id)
        {
            return _context.EventImage.Any(e => e.IdeventImage == id);
        }
    }
}