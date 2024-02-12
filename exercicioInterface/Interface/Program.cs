using Interface.Entities;
using Interface.Services;
using System.Globalization;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            string numContract = Console.ReadLine();
            Console.Write("Date (dd/MM/yyyy): ");
            DateOnly contractDate = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract contract = new Contract(numContract, contractDate, totalValue);

            ContractService contractService = new ContractService(new PayPalService());
            contractService.ProcessContract(contract, months);

            Console.WriteLine("Installments:");
            foreach (Installments installment in contract.InstallmentsList)
            {
                Console.WriteLine(installment);
            }
        }
    }
}