using Microsoft.AspNetCore.Mvc;

namespace MedicineProject.Controllers
{
    public class AdminPagesController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult CategoryList()
        {
            return View();
        }
        public IActionResult OrderList()
        {
            return View();
        }
        public IActionResult ProductList()
        {
            return View();
        }
    }
}
