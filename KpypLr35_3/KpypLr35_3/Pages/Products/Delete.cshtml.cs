using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KpypLr35_3.Data;
using KpypLr35_3.Models;

namespace KpypLr35_3.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly StoreContext _ctx;
        public DeleteModel(StoreContext ctx) => _ctx = ctx;

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _ctx.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (Product == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var prod = await _ctx.Products.FindAsync(id);
            if (prod != null)
            {
                _ctx.Products.Remove(prod);
                await _ctx.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
