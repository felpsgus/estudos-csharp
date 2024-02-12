using System.Globalization;

namespace Interface.Entities
{
    public class Installments(DateOnly dateDue, double value)
    {
        private DateOnly DueDate { get; set; } = dateDue;
        private double Value { get; set; } = value;

        public override string ToString()
        {
            return $"{DueDate.ToString("dd/MM/yyyy")} - {Value.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}