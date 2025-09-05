using Day2Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Day2Task.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ITIContext _context;

        public InstructorController(ITIContext context)
        {
            _context = context;
        }

        // GET: Instructor
        public async Task<IActionResult> Index()
        {
            var instructors = await _context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .ToListAsync();
            return View(instructors);
        }

        // GET: Instructor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var instructor = await _context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (instructor == null) return NotFound();
            return View(instructor);
        }

        // GET: Instructor/Create
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name");
            ViewBag.Courses = new SelectList(_context.Courses, "Id", "Name");
            return View();
        }

        // POST: Instructor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name", instructor.DepartmentId);
            ViewBag.Courses = new SelectList(_context.Courses, "Id", "Name", instructor.CourseId);
            return View(instructor);
        }

        // GET: Instructor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null) return NotFound();

            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name", instructor.DepartmentId);
            ViewBag.Courses = new SelectList(_context.Courses, "Id", "Name", instructor.CourseId);
            return View(instructor);
        }

        // POST: Instructor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Instructor instructor)
        {
            if (id != instructor.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorExists(instructor.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name", instructor.DepartmentId);
            ViewBag.Courses = new SelectList(_context.Courses, "Id", "Name", instructor.CourseId);
            return View(instructor);
        }

        // GET: Instructor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var instructor = await _context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (instructor == null) return NotFound();
            return View(instructor);
        }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorExists(int id)
        {
            return _context.Instructors.Any(e => e.Id == id);
        }
    }
}
