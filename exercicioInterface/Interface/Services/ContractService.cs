using Interface.Entities;
using Interface.Interfaces;

namespace Interface.Services
{
    public class ContractService(IPaymentService paymentService)
    {
        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {
                DateOnly date = contract.Date.AddMonths(i);
                double fullQuota = paymentService.Tax(basicQuota, i);
                contract.InstallmentsList.Add(new Installments(date, fullQuota));
            }
        }
    }
}