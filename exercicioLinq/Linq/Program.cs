using Linq.Entities;
using System.Globalization;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type the path of the file:");
            string path = Console.ReadLine();

            List<Employee> employees = new List<Employee>();

            using StreamReader sr = File.OpenText(path);
            while (!sr.EndOfStream)
            {
                string[] fields = sr.ReadLine().Split(',');
                string name = fields[0];
                string email = fields[1];
                double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                employees.Add(new Employee(name, email, salary));
            }

            Console.WriteLine("Enter the salary:");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<string> orderedList = employees.Where(x => x.Salary > value).OrderBy(x => x.Email).Select(x => x.Email).ToList();
            Console.WriteLine($"Email of people whose salary is more than {value.ToString("F2", CultureInfo.InvariantCulture)}:");
            foreach (string email in orderedList)
            {
                Console.WriteLine(email);
            }

            double sum = employees.Where(x => x.Name[0] == 'M').Sum(x => x.Salary);
            Console.WriteLine($"Sum of salary of people whose name starts with 'M': {sum.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}