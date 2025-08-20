using AppleShop.Data;
using AppleShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AppleShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ApplicationDbContext db, ILogger<AccountController> logger)
        {
            _db = db;
            _logger = logger;
        }

        /* ---------- ВХОД ---------- */
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user == null)
            {
                ModelState.AddModelError("", "Неверный логин или пароль");
                return View();
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserRole", user.Role);
            return RedirectToAction("Profile");
        }

        /* ---------- РЕГИСТРАЦИЯ ---------- */
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(string login, string password)
        {
            if (_db.Users.Any(u => u.Login == login))
            {
                ModelState.AddModelError("", "Логин уже используется");
                return View();
            }

            var user = new User { Login = login, Password = password };
            _db.Users.Add(user);
            _db.SaveChanges();

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserRole", user.Role);
            return RedirectToAction("Profile");
        }

        /* ---------- ПРОФИЛЬ ---------- */
        public IActionResult Profile()
        {
            var id = HttpContext.Session.GetInt32("UserId");
            if (id == null) return RedirectToAction("Login");

            var user = _db.Users.Find(id);
            return View(user);
        }

        /* ---------- ВЫХОД ---------- */
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
