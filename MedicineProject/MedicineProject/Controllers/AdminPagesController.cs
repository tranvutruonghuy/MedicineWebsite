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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminPagesController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            this._webHostEnvironment = webHostEnvironment;
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










        public async Task<IActionResult> AddProduct()
        {
            var categories = await _context
                .Categories
                .Select(c => new CategoryModel { Id = c.Id, Name= c.Name})
                .ToListAsync();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductViewModel viewModel)
        {
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string fileName = "";
            if(viewModel.Photo != null)
            {
                String uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                fileName = dateTime + "_" + viewModel.Photo.FileName;
                String filePath = Path.Combine(uploadFolder, fileName);
                viewModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));  
            }
            ProductModel product = new ProductModel
            {
                Name = viewModel.Name,
                CategoryId = viewModel.CategoryId,
                Description = viewModel.Description,
                ShortDescription = viewModel.ShortDescription,
                InStock = viewModel.InStock,
                Price = viewModel.Price,
                Unit = viewModel.Unit,
                Image = fileName
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("ProductList", "AdminPages");

        }
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var products = await _context.Products.ToListAsync();
            var categories = await _context
                .Categories
                .Select(c => new CategoryModel { Id = c.Id, Name = c.Name })
                .ToListAsync();
            ViewBag.Categories = categories;
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            EditProductViewModel tempProduct = new EditProductViewModel 
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Description = product.Description,
                ShortDescription = product.ShortDescription,
                InStock = product.InStock,
                Price = product.Price,
                Unit = product.Unit,
                Image = product.Image,

            };

            var categories = await _context
                .Categories
                .Select(c => new CategoryModel { Id = c.Id, Name = c.Name })
                .ToListAsync();
            ViewBag.Categories = categories;
            return View(tempProduct);
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(EditProductViewModel viewModel)
        {
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
             
            string fileName = "";
            if (viewModel.Photo != null)
            {
                String uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                fileName = dateTime + "_" + viewModel.Photo.FileName;
                String filePath = Path.Combine(uploadFolder, fileName);
                viewModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            var product = await _context.Products.FindAsync(viewModel.Id);
            if (product != null)
            {
                product.Name = viewModel.Name;
                product.CategoryId = viewModel.CategoryId;
                product.Description = viewModel.Description;
                product.ShortDescription = viewModel.ShortDescription;
                product.InStock = viewModel.InStock;
                product.Price = viewModel.Price;
                product.Unit = viewModel.Unit;
                product.Image = fileName;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ProductList", "AdminPages");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ProductList", "AdminPages");
        }

        public IActionResult OrderList()
        {
            return View();
        }
        
    }
}
