using KpypLr35_3.Data;
using KpypLr35_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KpypLr35_3.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly StoreContext _ctx;
        public CreateModel(StoreContext ctx) => _ctx = ctx;

        [BindProperty]
        public Category Category { get; set; } = new();

        public IActionResult OnGet() => Page();

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) return Page();
            _ctx.Categories.Add(Category);
            await _ctx.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
