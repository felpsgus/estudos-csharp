using System.Globalization;
using Order.Entities;
using Order.Entities.Enums;

namespace Order;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter client data: ");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Birth date (DD/MM/YYYY): ");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Enter order data: ");

        Console.Write("Status (PendingPayment/Processing/Shipped/Delivered): ");
        OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

        Client client = new(name, email, birthDate);
        Entities.Order order = new(DateTime.Now, status, client);

        Console.WriteLine();
        Console.Write("How many items to this order? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter #{i + 1} item data: ");

            Console.Write("Product name: ");
            string productName = Console.ReadLine();

            Console.Write("Product price: ");
            double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Product product = new(productName, productPrice);
            OrderItem orderItem = new(quantity, productPrice, product);

            order.AddItem(orderItem);
        }

        Console.WriteLine();
        Console.WriteLine("ORDER SUMMARY:");
        Console.WriteLine(order);
    }
}