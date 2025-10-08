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

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kaebus = await _context.Kaebused.FindAsync(id);
            if (kaebus == null)
            {
                return NotFound();
            }
            return View(kaebus);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var kaebus = await _context.Kaebused.FindAsync(id);
            return View(kaebus);
        }
        [HttpPost, ActionName("EditConfirmed")]
        public async Task<IActionResult> Edit([Bind("KuritarvitajadID, Firstname, Lastname, OpilaneVOpetaja, KuritarvitajaDescription, KuritegevusteArv, Kaebuse, KaebuseAdmin")] Kaebus kaebused)
        {
            if (ModelState.IsValid)
            {
                _context.Kaebused.Update(kaebused);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(kaebused);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kaebus = await _context.Kaebused.FirstOrDefaultAsync(m => m.KuritarvitajadID == id);
            if (kaebus == null)
            {
                return NotFound();
            }
            return View(kaebus);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kaebus = await _context.Kaebused.FindAsync(id);
            _context.Kaebused.Remove(kaebus);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
