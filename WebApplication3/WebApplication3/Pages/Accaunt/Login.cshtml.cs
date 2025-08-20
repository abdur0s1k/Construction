using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Data;
using WebApplication3.Services;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Pages.Accaunt
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly CustomAuthStateProvider _auth;

        public LoginModel(AppDbContext db, CustomAuthStateProvider auth)
        {
            _db = db;
            _auth = auth;
        }

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash))
            {
                ModelState.AddModelError(string.Empty, "Ќеверный email или пароль");
                return Page();
            }

            _auth.SignIn(user.Email); // или через HttpContext.Session, если не используешь CustomAuthStateProvider

            return RedirectToPage("/Accaunt/Account");
        }
    }
}
