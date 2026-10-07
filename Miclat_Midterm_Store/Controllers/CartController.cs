using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Miclat_Midterm_Store.Data;

namespace Miclat_Midterm_Store.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ CART
        public async Task<IActionResult> Index()
        {
            var cartItems = await _context.CartItems.ToListAsync();

            return View(cartItems);
        }

        // UPDATE QUANTITY
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int id, int quantity)
        {
            var item = await _context.CartItems.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            if (quantity < 1)
            {
                quantity = 1;
            }

            item.Quantity = quantity;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // DELETE CART ITEM
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var item = await _context.CartItems.FindAsync(id);

            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}   