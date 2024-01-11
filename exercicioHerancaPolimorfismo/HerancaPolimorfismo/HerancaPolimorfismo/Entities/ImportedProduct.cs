namespace HerancaPolimorfismo.Entities;

public class ImportedProduct : Product
{
    private double CustomFee { get; set; }

    public ImportedProduct()
    {
    }

    public ImportedProduct(string name, double price, double customFee) : base(name, price)
    {
        CustomFee = customFee;
    }

    public sealed override string PriceTag()
    {
        return $"{Name} $ {TotalPrice():F2} (Customs fee: $ {CustomFee:F2})";
    }

    private double TotalPrice()
    {
        return Price + CustomFee;
    }
}