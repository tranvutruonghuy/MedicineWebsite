using AspNetCoreGeneratedDocument;
using MedicineProject.Models;
using MedicineProject.Models.ViewModels;
using MedicineProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Controllers
{
    public class AdminPagesController : Controller
    {
        private readonly DataContext _context;
        public AdminPagesController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        



        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel viewModel)
        {
            int categoryParentID = int.Parse(viewModel.ParentID);
            var category = new CategoryModel
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                ParentID = categoryParentID,
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("CategoryList", "AdminPages");
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryModel viewModel)
        {
            var category = await _context.Categories.FindAsync(viewModel.Id);
            if (category != null) { 
                category.Name = viewModel.Name;
                category.Description = viewModel.Description;
                category.ParentID = viewModel.ParentID;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("CategoryList", "AdminPages");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("CategoryList", "AdminPages");
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
