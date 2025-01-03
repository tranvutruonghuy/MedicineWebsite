using Microsoft.AspNetCore.Mvc;

namespace MedicineProject.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ServiceDetails()
        {
            return View();
        }
    }
}
