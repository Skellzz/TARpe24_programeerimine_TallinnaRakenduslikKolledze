using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TallinnaRakenduslikKolledz.Models.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;
        public StudentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EnrollmentDate,PassportPhoto")] Student student)
        {
            if (!ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
                // return RedirectToAction(nameof(Index));
            }
            return View(student);

        }
        /**/


        /// <summary>
        /// Get Delete view for student
        /// </summary>
        /// <param name="id">id of student </param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var student = await _context.Students.FindAsync(id);
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students.FindAsync(id);
            return View(student);
        }
        [HttpPost, ActionName("EditConfirmed")]
        public async Task<IActionResult> Edit([Bind("Id, LastName, FirstName, EnrollmentDate,PassportPhotos, FunnyJokesMade, Smartnes")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(student);
        }
       
    }
}
