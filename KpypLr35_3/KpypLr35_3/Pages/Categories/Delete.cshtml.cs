using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KpypLr35_3.Data;
using KpypLr35_3.Models;

namespace KpypLr35_3.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly StoreContext _ctx;
        public DeleteModel(StoreContext ctx) => _ctx = ctx;

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Category = await _ctx.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (Category == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var cat = await _ctx.Categories.FindAsync(id);
            if (cat != null)
            {
                _ctx.Categories.Remove(cat);
                await _ctx.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
