using Files.Entities;
using System.Globalization;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type the path of the file: ");
            string path = Console.ReadLine() ?? throw new InvalidOperationException();

            try
            {
                string[] file = File.ReadAllLines(path);
                string pathOut = Path.GetDirectoryName(path) + @"\out\summary.csv";
                Directory.CreateDirectory(Path.GetDirectoryName(path) + @"\out");

                using StreamWriter sw = File.AppendText(pathOut);

                foreach (string line in file)
                {
                    string[] fields = line.Split(',');
                    Product prod = new Product(fields[0], double.Parse(fields[1], CultureInfo.InvariantCulture), int.Parse(fields[2]));

                    sw.WriteLine(prod.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}