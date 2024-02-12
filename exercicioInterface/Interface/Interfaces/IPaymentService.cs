namespace Interface.Interfaces
{
    public interface IPaymentService
    {
        double Tax(double value, int month);
    }
}