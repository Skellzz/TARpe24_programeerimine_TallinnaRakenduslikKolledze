using Microsoft.AspNetCore.Mvc;
using TallinnaRakenduslikKolledz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace TallinnaRakenduslikKolledz.Controllers

{
    public class KaebusedController : Controller
    {
        private readonly SchoolContext _context;
        public KaebusedController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Kaebused.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KuritarvitajadID, Firstname, Lastname, OpilaneVOpetaja, KuritarvitajaDescription, KuritegevusteArv, Kaebuse, KaebuseAdmin")] Kaebus kaebused)
        {
            if (!ModelState.IsValid)
            {
                _context.Kaebused.Add(kaebused);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
                // return RedirectToAction(nameof(Index));
            }
            return View(kaebused);

        }





    }
}
