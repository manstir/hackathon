namespace Surrogat.Areas.CentralBank.Controllers
{
    using System.Web.Mvc;

    using Surrogat.Areas.CentralBank.Repository;
    using Surrogat.Areas.CentralBank.ViewModels;

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
    }
}