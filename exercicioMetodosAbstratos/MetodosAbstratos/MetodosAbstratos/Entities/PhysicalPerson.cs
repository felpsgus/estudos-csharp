namespace MetodosAbstratos.Entities;

public class Individual : Person
{
    private double HealthExpenses { get; set; }

    public Individual()
    {
    }

    public Individual(string name, double anualIncome, double healthExpenses) : base(name, anualIncome)
    {
        HealthExpenses = healthExpenses;
    }

    public override double Tax()
    {
        if (AnualIncome < 20000.00)
        {
            return (AnualIncome * 0.15) - (HealthExpenses * 0.5);
        }
        else
        {
            return (AnualIncome * 0.25) - (HealthExpenses * 0.5);
        }
    }
}