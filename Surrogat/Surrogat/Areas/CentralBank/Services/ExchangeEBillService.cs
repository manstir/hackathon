namespace Surrogat.Areas.CentralBank.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentNHibernate.Utils;

    using Surrogat.Areas.CentralBank.Repository;
    using Surrogat.Shared;

    using WebGrease.Css.Extensions;

    public class ExchangeEBillService : IExchangeEBillService
    {
        public IEnumerable<BillDto> Exchange(IEnumerable<BillDto> bills, decimal targetAmount)
        {
            var billRepo = new BillRepository();
            decimal balance = 0;
            bills.ToList().ForEach(
                b =>
                {
                    balance += billRepo.CashBill(b.Token);
                });

            var targetBill = billRepo.CreateBill(targetAmount);
            var deltaBill =  billRepo.CreateBill(balance - targetAmount);

            yield return new BillDto{Amout = targetBill.Amount, Token = targetBill.Token};
            yield return new BillDto { Amout = deltaBill.Amount, Token = deltaBill.Token };
        }
    }
}