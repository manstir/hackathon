namespace Surrogat.Areas.CentralBank.Services
{
    using Surrogat.Shared;

    public interface IOrderIBillService
    {
        BillDto OrderBill (int issuerId, decimal amount);
    }
}