using KpypLr35_3.Data;
using KpypLr35_3.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KpypLr35_3.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly StoreContext _ctx;
        public IList<Category> Categories { get; set; } = default!;
        public IndexModel(StoreContext ctx) => _ctx = ctx;

        public async Task OnGetAsync()
        {
            Categories = await _ctx.Categories
                .Include(c => c.Products)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
    }
}
