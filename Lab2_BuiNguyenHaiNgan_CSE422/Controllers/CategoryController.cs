using Lab2_BuiNguyenHaiNgan_CSE422.Models;
using Lab2_BuiNguyenHaiNgan_CSE422.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2_BuiNguyenHaiNgan_CSE422.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                ModelState.AddModelError("Title", "Title is required.");
                return View();
            }
            var category = new Category
            (
                title
            );
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(int id, string title)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            category.Title = title;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound(); 
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok();
        }


    }
}
