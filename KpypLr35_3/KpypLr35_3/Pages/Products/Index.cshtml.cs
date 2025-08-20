using KpypLr35_3.Data;
using KpypLr35_3.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KpypLr35_3.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly StoreContext _ctx;
        public IList<Product> Products { get; set; } = default!;

        public IndexModel(StoreContext ctx) => _ctx = ctx;

        public async Task OnGetAsync()
        {
            Products = await _ctx.Products
                .Include(p => p.Category)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }
    }
}
