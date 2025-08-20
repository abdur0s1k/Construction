// Pages/Products/Create.cshtml.cs
using KpypLr35_3.Data;
using KpypLr35_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;   // ← для ILogger

namespace KpypLr35_3.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly StoreContext _ctx;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(StoreContext ctx, ILogger<CreateModel> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public SelectList? CategoryList { get; set; }

        public async Task OnGetAsync()
        {
            var cats = await _ctx.Categories.OrderBy(c => c.Name).ToListAsync();
            CategoryList = new SelectList(cats, nameof(Category.Id), nameof(Category.Name));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // 1) Логируем в начале
            _logger.LogInformation("OnPostAsync: входные данные: Name={Name}, Price={Price}, CategoryId={CategoryId}",
                                    Product.Name, Product.Price, Product.CategoryId);

            // 2) Проверяем ModelState
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState invalid. Errors:");
                foreach (var kv in ModelState)
                {
                    foreach (var err in kv.Value.Errors)
                        _logger.LogWarning(" - {Field}: {ErrorMessage}", kv.Key, err.ErrorMessage);
                }

                // заново сборим список категорий, чтобы страница корректно перерисовалась
                var cats = await _ctx.Categories.OrderBy(c => c.Name).ToListAsync();
                CategoryList = new SelectList(cats, nameof(Category.Id), nameof(Category.Name));
                return Page();
            }

            // 3) Проверим, что такая категория существует
            var category = await _ctx.Categories.FindAsync(Product.CategoryId);
            if (category is null)
            {
                _logger.LogError("Категория с Id={CategoryId} не найдена", Product.CategoryId);
                ModelState.AddModelError("Product.CategoryId", "Выбранная категория не существует");
                var cats = await _ctx.Categories.OrderBy(c => c.Name).ToListAsync();
                CategoryList = new SelectList(cats, nameof(Category.Id), nameof(Category.Name));
                return Page();
            }

            // 4) Добавляем и сохраняем
            _ctx.Products.Add(Product);
            try
            {
                var changes = await _ctx.SaveChangesAsync();
                _logger.LogInformation("SaveChangesAsync: внесено изменений = {Count}", changes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при SaveChangesAsync");
                ModelState.AddModelError(string.Empty, "Ошибка при сохранении в базу: " + ex.Message);
                
                var cats = await _ctx.Categories.OrderBy(c => c.Name).ToListAsync();
                CategoryList = new SelectList(cats, nameof(Category.Id), nameof(Category.Name));
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
