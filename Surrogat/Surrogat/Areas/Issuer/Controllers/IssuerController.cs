using System;
using System.Web.Mvc;
using Surrogat.Areas.CentralBank.Services;
using Surrogat.Areas.Issuer.Models;
using Surrogat.Areas.Issuer.ViewModels;

namespace Surrogat.Areas.Issuer.Controllers
{
    public class IssuerController : Controller
    {
        public const int IssuerId = 1;

        // GET: Issuer/AccountsManagement
        public ActionResult Index()
        {
            var accountsRepository = new AccountsRepository();
            var accounts = accountsRepository.GetAccounts();

            var billsRepository = new BillsRepository();
            var bills = billsRepository.GetBills();

            var model = new IssuerViewModel()
            {
                Accounts = accounts,
                Bills = bills
            };
            return View(model);
        }

        public ActionResult Buy(decimal amount)
        {
            var orderEBillService = new OrderEBillService();
            var orderedBill = orderEBillService.OrderBill(IssuerId, amount);

            var bill = new BillBE
            {
                Amount = orderedBill.Amout,
                BoughtOn = DateTime.Now,
                Token = orderedBill.Token,
            };

            var billsRepository = new BillsRepository();
            billsRepository.AddBill(bill);

            return RedirectToAction("index");
        }
    }
}