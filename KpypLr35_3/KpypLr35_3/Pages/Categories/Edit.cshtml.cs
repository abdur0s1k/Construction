using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KpypLr35_3.Data;
using KpypLr35_3.Models;

namespace KpypLr35_3.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly StoreContext _context;

        public EditModel(StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (Category == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Attach(Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Categories.AnyAsync(c => c.Id == Category.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
