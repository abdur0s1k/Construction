using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Data;
using WebApplication3.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Pages.Accaunt
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _db;

        public RegisterModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public User User { get; set; } = new();

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (await _db.Users.AnyAsync(u => u.Email == User.Email))
            {
                ModelState.AddModelError(string.Empty, "ѕользователь с такой почтой уже существует");
                return Page();
            }

            User.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password);
            _db.Users.Add(User);
            await _db.SaveChangesAsync();

            // “ут можно добавить авторизацию

            return RedirectToPage("/Accaunt/Account");
        }
    }
}
