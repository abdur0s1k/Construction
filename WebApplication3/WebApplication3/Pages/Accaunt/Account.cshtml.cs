using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Pages.Accaunt
{
    public class AccountModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly CustomAuthStateProvider _auth;

        public AccountModel(AppDbContext db, CustomAuthStateProvider auth)
        {
            _db = db;
            _auth = auth;
        }

        [BindProperty]
        public User? UserData { get; set; }

        [BindProperty]
        public string NewPassword { get; set; } = "";

        public async Task<IActionResult> OnGetAsync()
        {
            var state = await _auth.GetAuthenticationStateAsync();
            var email = state.User.Identity?.Name;

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToPage("/Accaunt/Login");
            }

            UserData = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string action)
        {
            var state = await _auth.GetAuthenticationStateAsync();
            var email = state.User.Identity?.Name;

            if (string.IsNullOrEmpty(email))
                return RedirectToPage("/Accaunt/Login");

            UserData = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (UserData == null)
                return RedirectToPage("/Accaunt/Login");

            switch (action)
            {
                case "save":
                    if (!string.IsNullOrWhiteSpace(NewPassword))
                        UserData.PasswordHash = BCrypt.Net.BCrypt.HashPassword(NewPassword);

                    _db.Users.Update(UserData);
                    await _db.SaveChangesAsync();
                    break;

                case "delete":
                    _db.Users.Remove(UserData);
                    await _db.SaveChangesAsync();
                    _auth.SignOut();
                    return RedirectToPage("/Accaunt/Login");

                case "logout":
                    _auth.SignOut();
                    return RedirectToPage("/Accaunt/Login");
            }

            return RedirectToPage();
        }
    }
}
