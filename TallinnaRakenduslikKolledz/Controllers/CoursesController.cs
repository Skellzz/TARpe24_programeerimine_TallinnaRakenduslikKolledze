using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;
        public CoursesController(SchoolContext context)
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            var courses = _context.Courses.Include(c => c.Department)
                .AsNoTracking();

            return View(courses);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Vaatetüüp"] = "Create";
            PopulateDepartmentDropDownList();
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
               // PopulateDepartmentDropDownList(course.DepartmentID);
                
            }
            ViewData["Vaatetüüp"] = "Create";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }
            ViewData["Vaatetüüp"] = "Delete";
            var course = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(nameof(Details), course);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Vaatetüüp"] = "Delete";
            if (_context.Courses == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            { 
                _context.Courses.Remove(course);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Vaatetüüp"] = "Details";
            var course = await _context.Courses.FindAsync(id);
            return View(nameof(Details), course);
        }
        private void PopulateDepartmentDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Vaatetüüp"] = "Edit";
            var course = await _context.Courses.FindAsync(id);
            return View("Create", course);

        }

        [HttpPost, ActionName("EditConfirmed")]
        public async Task<IActionResult> Edit([Bind("Title, Credits, Department,")] Course course)
        {
            if (ModelState.IsValid)
            { 
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["Vaatetüüp"] = "Edit";
            return View(nameof(Create), course);
        }
    }
}
