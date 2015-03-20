namespace Surrogat.Areas.CentralBank.Services
{
    using Surrogat.Shared;

    public class OrderEBillService : IOrderIBillService
    {
        public BillDto OrderBill(int issuerId, double amount)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IOrderIBillService
    {
        BillDto OrderBill (int issuerId, double amount);
    }
}