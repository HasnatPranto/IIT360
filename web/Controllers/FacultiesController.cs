using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IIT360_Web.Models;
using ReflectionIT.Mvc.Paging;

namespace IIT360_Web.Controllers
{
    public class FacultiesController : Controller
    {
        private readonly iit360Context _context;

        public FacultiesController(iit360Context context)
        {
            _context = context;
        }

        // GET: Faculties
        public async Task<IActionResult> Index(int pnum=1) 
        {
            var f = _context.Faculty.AsNoTracking().OrderBy(f => f.Name);
            var faculties = await PagingList.CreateAsync(f, 5, pnum);
            return View(faculties);
            //var iit360Context = _context.Faculty.Include(f => f.FkFacultyImageNavigation);
            //return View(await iit360Context.ToListAsync());
        }

        // GET: Faculties/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculty
                .Include(f => f.FkFacultyImageNavigation)
                .FirstOrDefaultAsync(m => m.FacultyId == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // GET: Faculties/Create
        public IActionResult Create()
        {
            ViewData["FkFacultyImage"] = new SelectList(_context.Image, "ImageId", "ImgName");
            return View();
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacultyId,Name,Designation,Qualification,Links,Status,AboutMe,Teachings,FkFacultyImage")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faculty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkFacultyImage"] = new SelectList(_context.Image, "ImageId", "ImgName", faculty.FkFacultyImage);
            return View(faculty);
        }

        // GET: Faculties/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculty.FindAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            ViewData["FkFacultyImage"] = new SelectList(_context.Image, "ImageId", "ImgName", faculty.FkFacultyImage);
            return View(faculty);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FacultyId,Name,Designation,Qualification,Links,Status,AboutMe,Teachings,FkFacultyImage")] Faculty faculty)
        {
            if (id != faculty.FacultyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faculty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyExists(faculty.FacultyId))
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
            ViewData["FkFacultyImage"] = new SelectList(_context.Image, "ImageId", "ImgName", faculty.FkFacultyImage);
            return View(faculty);
        }

        // GET: Faculties/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculty
                .Include(f => f.FkFacultyImageNavigation)
                .FirstOrDefaultAsync(m => m.FacultyId == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var faculty = await _context.Faculty.FindAsync(id);
            _context.Faculty.Remove(faculty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultyExists(string id)
        {
            return _context.Faculty.Any(e => e.FacultyId == id);
        }
    }
}
