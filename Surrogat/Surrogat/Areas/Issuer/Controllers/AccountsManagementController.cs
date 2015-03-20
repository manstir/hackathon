using System.Web.Mvc;
using Surrogat.Areas.Issuer.Models;
using Surrogat.Areas.Issuer.ViewModels;

namespace Surrogat.Areas.Issuer.Controllers
{
    public class AccountsManagementController : Controller
    {
        // GET: Issuer/AccountsManagement
        public ActionResult Index()
        {
            return RedirectToAction("ShowAccounts");
        }

        public ActionResult ShowAccounts()
        {
            var repository = new AccountsRepository();
            var accounts = repository.GetAccounts();

            var model = new ShowAccountsViewModel()
            {
                Accounts = accounts
            };
            return View(model);
        }

        public ActionResult CreateNewAccount()
        {
            var emptyAccount = new NewAccountDTO();
            return View(emptyAccount);
        }

        [HttpPost]
        public ActionResult CreateNewAccount(NewAccountDTO newAccount)
        {
            ValidateModel(newAccount);

            if (!ModelState.IsValid)
            {
                return View(newAccount);
            }
            
            var newAccountBe = new AccountBE
            {
                Alias = newAccount.Alias,
                Name = newAccount.Name,
                PasswordHash = AccountsRepository.CreatePasswordHash(newAccount.Password),
                Debt = 0,
            };

            var repository = new AccountsRepository();
            repository.AddAccount(newAccountBe);

            return RedirectToAction("ShowAccounts");
        }
    }
}