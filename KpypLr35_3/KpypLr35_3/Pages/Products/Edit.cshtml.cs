using KpypLr35_3.Data;
using KpypLr35_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KpypLr35_3.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly StoreContext _ctx;
        public EditModel(StoreContext ctx) => _ctx = ctx;

        [BindProperty]
        public Product Product { get; set; } = default!;

        public SelectList CategoryList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _ctx.Products.FindAsync(id)
                      ?? throw new InvalidOperationException("Не найден товар");

            var cats = await _ctx.Categories.OrderBy(c => c.Name).ToListAsync();
            CategoryList = new SelectList(cats, nameof(Category.Id), nameof(Category.Name), Product.CategoryId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var cats = await _ctx.Categories.OrderBy(c => c.Name).ToListAsync();
                CategoryList = new SelectList(cats, nameof(Category.Id), nameof(Category.Name), Product.CategoryId);
                return Page();
            }

            _ctx.Attach(Product).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
