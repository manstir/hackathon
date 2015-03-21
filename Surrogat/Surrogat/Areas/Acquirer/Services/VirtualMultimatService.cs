using System;
using Surrogat.Areas.Acquirer.Repository;
using Surrogat.Areas.CentralBank.Repository;
using Surrogat.Areas.CentralBank.Services;

namespace Surrogat.Areas.Acquirer.Services
{
    public class VirtualMultimatService
    {
        public void Deposit(int merchantId, string token)
        {
            var merchantRepo = new MerchantRepository();
            var merchant = merchantRepo.GetMerchantById(merchantId);

            var billRepo = new BillRepository();
            var bill = billRepo.GetBillByToken(new Guid(token));

            merchantRepo.UpdateSaldo(merchantId, bill.Amount);

            var orderBillService = new OrderEBillService();
            orderBillService.DepositBill(merchant.AcquirerId, token);
        }
    }
}
