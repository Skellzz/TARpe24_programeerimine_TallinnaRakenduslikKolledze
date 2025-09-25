using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class DepartmentsController : Controller
    {
        private const string V = "Delete";
        private readonly SchoolContext _context;
       
        public DepartmentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Departments.Include(d => d.Administrator);
            return View(await schoolContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        { 
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName");
            //ViewData["StudentId"] = new SelectList (_context.Instructors, "Id", "LastName", "FirstName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Budget, StartDate, RowVersion, InstructorID, PhoneNumber, Aadress, Email")] Department department)
        {
            if (ModelState.IsValid)
            { 
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", department.InstructorID);
            //ViewData["CourseStatus"] = new SelectList(_context.Instructors, "Id", "LastName", "FirstName", department.InstructorID);

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            { 
                return NotFound();
            }
            var department = await _context.Departments
                .Include(d => d.Administrator)
                .FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);



        }
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Department department)
        {
            ViewData["Vaatetüüp"] = "Delete";
            if (await _context.Departments.AnyAsync(m => m.DepartmentID == department.DepartmentID))
            {

                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Vaatetüüp"] = "Details";
            var department = await _context.Departments.FindAsync(id);
            return View(nameof(Delete),department);

        }

    }
}
