using System.Web.Mvc;
using Surrogat.Areas.Issuer.ViewModels;

namespace Surrogat.Areas.Issuer.Controllers
{
    public class OverviewController : Controller
    {
        // GET: Issuer/AccountsManagement
        public ActionResult Index()
        {
            return RedirectToAction("Overview");
        }

        public ActionResult Overview()
        {
            var repository = new AccountsRepository();
            var accounts = repository.GetAccounts();

            var model = new OverviewViewModel()
            {
                Accounts = accounts
            };
            return View(model);
        }
    }
}