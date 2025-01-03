using Microsoft.AspNetCore.Mvc;

namespace MedicineProject.Controllers
{
    public class TipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TipDetails()
        {
            return View();
        }
    }
}
