using Microsoft.AspNetCore.Mvc;
using TallinnaRakenduslikKolledz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace TallinnaRakenduslikKolledz.Controllers

{
    public class TEKNOController : Controller
    {
        private readonly SchoolContext _context;
        public TEKNOController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeknoNimetus, TeknoDescription, TeknoArv, TeknoID, TeknoHind, TeknoAdmin")] TEKNO Teknos)
        {
            if (!ModelState.IsValid)
            {
                _context.Teknos.Add(Teknos);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
                // return RedirectToAction(nameof(Index));
            }
            return View(Teknos);

        }





    }
}
