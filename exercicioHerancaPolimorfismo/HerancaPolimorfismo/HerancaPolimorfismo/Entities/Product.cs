namespace HerancaPolimorfismo.Entities;

public class Product
{
    protected string Name { get; set; }
    protected double Price { get; set; }

    public Product()
    {
    }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public virtual string PriceTag()
    {
        return $"{Name} $ {Price:F2}";
    }
}