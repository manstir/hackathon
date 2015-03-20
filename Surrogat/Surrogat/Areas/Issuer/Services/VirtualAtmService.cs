using System;
using Surrogat.Areas.CentralBank.Repository;
using Surrogat.Areas.CentralBank.Services;
using Surrogat.Areas.Issuer.Controllers;
using Surrogat.Shared;

namespace Surrogat.Areas.Issuer.Services
{
    public class VirtualAtmService
    {
        public VirtualAtmService()
        {
        }

        public BillDto WithdrawBill(int accountId, decimal amount)
        {
            var accountsRepo = new AccountsRepository();
            var account = accountsRepo.GetAccountById(accountId);

            if (account == null)
            {
                throw new Exception("No account found with this ID");
            }

            var billRepo = new BillsRepository();
            var bill = billRepo.WithdrawBill(amount);

            account.Debt += bill.Amount;
            accountsRepo.UpdateAccount(account);

            return new BillDto { Amout = bill.Amount, Token = bill.Token };
        }
    }
}