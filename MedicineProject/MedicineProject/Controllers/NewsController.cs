using Microsoft.AspNetCore.Mvc;

namespace MedicineProject.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewsDetails()
        {
            return View();
        }
    }
}
