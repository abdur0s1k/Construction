using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AppleShop.Data;
using AppleShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AppleShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ApplicationDbContext context, ILogger<OrderController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            var cartId = HttpContext.Session.GetString("CartId");
            if (string.IsNullOrEmpty(cartId))
            {
                _logger.LogWarning("CartId is null or empty");
                ModelState.AddModelError("", "Идентификатор корзины не найден");
                return View(order);
            }

            var cartItems = await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.CartId == cartId)
                .ToListAsync();

            if (!cartItems.Any())
            {
                _logger.LogWarning("Попытка оформления заказа с пустой корзиной");
                ModelState.AddModelError("", "Корзина пуста");
                return View(order);
            }

            try
            {
                /* ==== фикс: берём UserId из сессии ==== */
                var uid = HttpContext.Session.GetInt32("UserId");
                order.UserId = uid?.ToString() ?? "Guest";

                order.OrderDate = DateTime.Now;
                order.Status = "Pending";
                order.OrderItems = new List<OrderItem>();

                foreach (var item in cartItems)
                {
                    order.OrderItems.Add(new OrderItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Product.Price
                    });
                }

                order.Total = cartItems.Sum(c => c.Quantity * c.Product.Price);

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                /* очищаем корзину */
                _context.CartItems.RemoveRange(cartItems);
                await _context.SaveChangesAsync();
                HttpContext.Session.Remove("CartId");

                _logger.LogInformation("Заказ {OrderId} успешно создан", order.Id);
                return RedirectToAction("OrderConfirmation", new { id = order.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании заказа");
                ModelState.AddModelError("", $"Ошибка при оформлении заказа: {ex.Message}");
                return View(order);
            }
        }

        public async Task<IActionResult> OrderConfirmation(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
