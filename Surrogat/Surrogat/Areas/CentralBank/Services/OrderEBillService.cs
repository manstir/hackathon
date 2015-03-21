using System;

namespace Surrogat.Areas.CentralBank.Services
{
    using Surrogat.Areas.CentralBank.Repository;
    using Surrogat.Shared;

    public class OrderEBillService : IOrderIBillService
    {
        public OrderEBillService()
        {
        }

        public BillDto OrderBill(int issuerId, decimal amount)
        {
            var billRepo = new BillRepository();
            var bill = billRepo.CreateBill(amount);

            var issuerRepo = new IssuerRepository();
            issuerRepo.UpdateIssuerBalance(issuerId, amount);

            return new BillDto { Amout = bill.Amount, Token = bill.Token };
        }

        public void DepositBill(int acquirerId, string token)
        {
            var t = new Guid(token);
            var billRepo = new BillRepository();
            var bill = billRepo.GetBillByToken(t);
            billRepo.CashBill(t);

            var acquirerRepo = new AcquirerRepository();
            acquirerRepo.UpdateAcquirerBalance(acquirerId, bill.Amount);
        }
    }
}