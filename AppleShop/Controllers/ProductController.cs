using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppleShop.Data;


namespace AppleShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? categoryId, int page = 1)
        {
            int pageSize = 9; // Количество товаров на странице
            var products = _context.Products

                .Include(p => p.Category)
                .AsQueryable();

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId);
            }

            var count = await products.CountAsync();
            var items = await products
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.CurrentCategory = categoryId;
            ViewBag.Page = page;
            ViewBag.TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            return View(items);
        }
    }
}
