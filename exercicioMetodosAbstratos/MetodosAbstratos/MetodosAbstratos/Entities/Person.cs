namespace MetodosAbstratos.Entities;

public abstract class Person
{
    public string Name { get; set; }
    protected double AnualIncome { get; set; }

    protected Person()
    {
    }

    protected Person(string name, double anualIncome)
    {
        Name = name;
        AnualIncome = anualIncome;
    }

    public abstract double Tax();
}