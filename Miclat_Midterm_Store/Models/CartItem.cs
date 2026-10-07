using System.ComponentModel.DataAnnotations;

namespace Miclat_Midterm_Store.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; } = "";

        public decimal Price { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}