using Lab2_BuiNguyenHaiNgan_CSE422.Models;
using Lab2_BuiNguyenHaiNgan_CSE422.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab2_BuiNguyenHaiNgan_CSE422.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Title");
            var devices = _context.Devices.Include(d => d.Category).ToList();
            return View(devices);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Device device)
        {
                device.DateOfEntry = DateTime.Now;
                _context.Devices.Add(device);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Title");
            var device = _context.Devices.FirstOrDefault(c => c.Id == id);
            return View(device);
        }

        [HttpPost]
        public IActionResult Edit(Device device)
        {

                var existingDevice = _context.Devices.FirstOrDefault(d => d.Id == device.Id);

                if (existingDevice == null)
                {
                    return NotFound();
                }

                existingDevice.Code = device.Code;
                existingDevice.Name = device.Name;
                existingDevice.CategoryId = device.CategoryId;
                existingDevice.Status = device.Status;
                existingDevice.DateOfEntry = DateTime.Now;  

                _context.SaveChanges();

                return RedirectToAction("Index");
         
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var device = _context.Devices.FirstOrDefault(d => d.Id == id);
            if (device == null)
            {
                return NotFound(); 
            }

            _context.Devices.Remove(device);
            _context.SaveChanges();
            return Ok();  
        }




    }
}
