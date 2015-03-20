namespace Surrogat.Areas.CentralBank.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using FluentNHibernate.Conventions.AcceptanceCriteria;

    using Surrogat.Areas.CentralBank.Repository;
    using Surrogat.Areas.CentralBank.ViewModels;
    using Surrogat.Shared;

    public class BankController  : Controller
    {
        public BankController()
        {
        }

        public ActionResult Index()
        {
            var viewModel = new BankSummaryViewModel() { IssuerIds = new[] { 1, 2, 3 }, AcquirerIds = new[]{1,2,3}};
            return this.View("Index", viewModel);
        }

        public ActionResult OrderTest()
        {
            var srv = new Services.OrderEBillService();
            srv.OrderBill(1, 200);
            return RedirectToAction("index");
        }

        public ActionResult ExchangeTest()
        {
            var srv = new Services.ExchangeEBillService();
            var x = srv.Exchange(new[] {new BillDto{Token = new Guid("29be1e67-a008-4a53-b248-c820d746df86")}, new BillDto{Token = new Guid("29bf48a3-e2f1-49b7-8787-68d693fe7c87") }}, 45);
            x.ToList();
            return RedirectToAction("index");
        }

        public ActionResult IssuerAccount(int issuerId)
        {
            var repo = new IssuerRepository();
            var issuer = repo.GetIssuerById(issuerId);
            var viewModel = new IssuerViewModel { IssuerId = issuer.IssuerId, Saldi = issuer.Saldi };

            return this.View("Issuer", viewModel);
        }
    }
}