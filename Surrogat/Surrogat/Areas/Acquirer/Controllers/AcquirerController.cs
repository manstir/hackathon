using System;
using System.Web.Mvc;
using Surrogat.Areas.Acquirer.Repository;
using Surrogat.Areas.Acquirer.Services;
using Surrogat.Areas.Acquirer.ViewModel;

namespace Surrogat.Areas.Acquirer.Controllers
{
    public class AcquirerController : Controller
    {
        private VirtualMultimatService _virtualMultimatService;

        public AcquirerController()
        {
            _virtualMultimatService = new VirtualMultimatService();
        }

        public ActionResult Index(int acquirerId)
        {
            return View("index", new AcquirerViewModel
            {
                Merchants = new MerchantRepository().GetMerchants(acquirerId)
            });
        }

        [HttpGet]
        public void Deposit(int merchantId, string token)
        {
            merchantId = 4;
            _virtualMultimatService.Deposit(merchantId, token);
        }
    }
}
