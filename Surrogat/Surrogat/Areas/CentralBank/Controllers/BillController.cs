namespace Surrogat.Areas.CentralBank.Controllers
{
    using System.Web.Mvc;

    using Surrogat.Areas.CentralBank.Repository;
    using Surrogat.Areas.CentralBank.ViewModels;

    public class BillController  : Controller
    {
        private BillRepository billRepository;

        public BillController()
        {
            this.billRepository = new BillRepository();
        }

        public ActionResult List()
        {
            var viewModel = new BillListViewModel { Bills = this.billRepository.GetAllBills() };
            return this.View("Bills", viewModel);
        }
    }
}