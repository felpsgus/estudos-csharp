using System.Globalization;

namespace Files.Entities
{
    public class Product(string name, double price, int quantity)
    {
        private string Name { get; set; } = name;
        private double Price { get; set; } = price;
        private int Quantity { get; set; } = quantity;

        private double Total()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return $"{Name},{Total().ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}