using Lab2_BuiNguyenHaiNgan_CSE422.Models;
using Lab2_BuiNguyenHaiNgan_CSE422.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_BuiNguyenHaiNgan_CSE422.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newUser = new User(
                user.FullName, 
                user.Email, 
                user.Role, 
                user.PhoneNumber
                );

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _context.Users.FirstOrDefault(c => c.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            var updateUser = _context.Users.FirstOrDefault(c => c.Id == user.Id);
            if (updateUser == null)
            {
                return NotFound();
            }

            updateUser.FullName = user.FullName;
            updateUser.Email = user.Email;
            updateUser.PhoneNumber = user.PhoneNumber;
            updateUser.Role = user.Role;

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok();
        }

    }
}
