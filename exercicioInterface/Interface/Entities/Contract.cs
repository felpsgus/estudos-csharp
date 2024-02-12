namespace Interface.Entities
{
    public class Contract(string numContract, DateOnly contractDate, double totalValue)
    {
        public string NumContract { get; set; } = numContract;
        public DateOnly Date { get; set; } = contractDate;
        public double TotalValue { get; set; } = totalValue;
        public List<Installments> InstallmentsList { get; set; } = new List<Installments>();

    }
}