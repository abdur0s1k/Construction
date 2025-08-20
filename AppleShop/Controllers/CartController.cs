using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AppleShop.Data;
using AppleShop.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppleShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CartController> _logger;

        public CartController(ApplicationDbContext context, ILogger<CartController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var cartId = GetCartId();
                _logger.LogInformation("Fetching cart items for CartId: {CartId}", cartId);
                var cartItems = await _context.CartItems
                    .Include(c => c.Product)
                    .Where(c => c.CartId == cartId)
                    .ToListAsync();
                _logger.LogInformation("Found {Count} items in cart", cartItems.Count);
                return View(cartItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching cart items");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            try
            {
                _logger.LogInformation("Adding product {ProductId} with quantity {Quantity}", productId, quantity);
                var product = await _context.Products.FindAsync(productId);
                if (product == null)
                {
                    _logger.LogWarning("Product {ProductId} not found", productId);
                    return NotFound();
                }

                var cartId = GetCartId();
                _logger.LogInformation("CartId: {CartId}", cartId);
                var cartItem = await _context.CartItems
                    .FirstOrDefaultAsync(c => c.CartId == cartId && c.ProductId == productId);

                if (cartItem == null)
                {
                    cartItem = new CartItem
                    {
                        CartId = cartId,
                        ProductId = productId,
                        Quantity = quantity
                    };
                    _context.CartItems.Add(cartItem);
                    _logger.LogInformation("Added new cart item for product {ProductId}", productId);
                }
                else
                {
                    cartItem.Quantity += quantity;
                    _context.Update(cartItem);
                    _logger.LogInformation("Updated cart item for product {ProductId}", productId);
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation("Changes saved successfully");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding product {ProductId} to cart", productId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            try
            {
                _logger.LogInformation("Removing cart item {CartItemId}", id);
                var cartItem = await _context.CartItems.FindAsync(id);
                if (cartItem == null)
                {
                    _logger.LogWarning("Cart item {CartItemId} not found", id);
                    return NotFound();
                }

                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Cart item {CartItemId} removed", id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing cart item {CartItemId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        private string GetCartId()
        {
            var cartId = HttpContext.Session.GetString("CartId");
            if (string.IsNullOrEmpty(cartId))
            {
                cartId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("CartId", cartId);
                _logger.LogInformation("Created new CartId: {CartId}", cartId);
            }
            else
            {
                _logger.LogInformation("Using existing CartId: {CartId}", cartId);
            }
            return cartId;
        }
    }
}