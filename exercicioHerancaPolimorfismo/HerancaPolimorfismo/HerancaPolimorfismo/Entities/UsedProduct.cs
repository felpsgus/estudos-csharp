namespace HerancaPolimorfismo.Entities;

public class UsedProduct : Product
{
    private DateTime ManufactureDate { get; set; }

    public UsedProduct()
    {
    }

    public UsedProduct(string name, double price, DateTime manufactureDate) : base(name, price)
    {
        ManufactureDate = manufactureDate;
    }

    public sealed override string PriceTag()
    {
        return $"{Name} (used) $ {Price:F2} (Manufacture date: {ManufactureDate:dd/MM/yyyy})";
    }
}