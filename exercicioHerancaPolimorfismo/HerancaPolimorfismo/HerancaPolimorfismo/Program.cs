
using System.Globalization;
using HerancaPolimorfismo.Entities;


namespace HerancaPolimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            List<Product> products = new List<Product>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Product #{i + 1} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (type == 'c')
                {
                    Product product = new Product(name, price);
                    products.Add(product);
                }
                else if (type == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    UsedProduct usedProduct = new UsedProduct(name, price, manufactureDate);
                    products.Add(usedProduct);
                }
                else if (type == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    ImportedProduct importedProduct = new ImportedProduct(name, price, customFee);
                    products.Add(importedProduct);
                }
                else
                {
                    Console.WriteLine("Invalid type!");
                }
                Console.WriteLine();
            }

            Console.WriteLine("PRICE TAGS:");
            foreach (Product product in products)
            {
                Console.WriteLine(product.PriceTag());
            }
        }
    }
}


