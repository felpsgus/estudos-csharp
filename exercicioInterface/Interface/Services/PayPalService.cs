using Interface.Interfaces;

namespace Interface.Services
{
    public class PayPalService : IPaymentService
    {
        private const double MonthlyInterest = 0.01;
        private const double Fee = 0.02;

        public double Tax(double value, int month)
        {
            double interest = value * MonthlyInterest * month;
            double paymentFee = (value + interest) * Fee;
            return value + interest + paymentFee;
        }
    }
}