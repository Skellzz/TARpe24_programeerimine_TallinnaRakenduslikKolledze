using Microsoft.AspNetCore.Mvc;

namespace TallinnaRakenduslikKolledz.Models.Controllers
{
    public class InstructorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
