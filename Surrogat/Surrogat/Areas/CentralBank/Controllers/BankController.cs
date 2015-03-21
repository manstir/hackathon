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

        public ActionResult IssuerAccount(int issuerId)
        {
            var repo = new IssuerRepository();
            var issuer = repo.GetIssuerById(issuerId);
            var viewModel = new IssuerViewModel { IssuerId = issuer.IssuerId, Saldi = issuer.Saldi };

            return this.View("Issuer", viewModel);
        }
    }
}