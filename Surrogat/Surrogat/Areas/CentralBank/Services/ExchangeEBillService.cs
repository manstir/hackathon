using System;
using System.Collections.Generic;
using System.Linq;
using Surrogat.Areas.CentralBank.Repository;
using Surrogat.Shared;

namespace Surrogat.Areas.CentralBank.Services
{
    public class ExchangeEBillService : IExchangeEBillService
    {
        public IEnumerable<BillDto> Exchange(IEnumerable<Guid> bills, decimal targetAmount)
        {
            var billRepo = new BillRepository();
            decimal balance = 0;
            bills.ToList().ForEach(
                b =>
                {
                    balance += billRepo.CashBill(b);
                });

            var targetBill = billRepo.CreateBill(targetAmount);
            var deltaBill =  billRepo.CreateBill(balance - targetAmount);

            yield return new BillDto{Amout = targetBill.Amount, Token = targetBill.Token};
            yield return new BillDto { Amout = deltaBill.Amount, Token = deltaBill.Token };
        }
    }
}