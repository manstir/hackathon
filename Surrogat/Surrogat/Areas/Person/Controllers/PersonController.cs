using System.Web.Mvc;
using Surrogat.Areas.Person.Repository;
using Surrogat.Areas.Person.ViewModels;

namespace Surrogat.Areas.Person.Controllers
{
    public class PersonController : Controller
    {
        private PersonRepository _personRepository;

        public PersonController()
        {
            _personRepository = new PersonRepository();
        }

        public ActionResult Index(int personId)
        {
            var model = new PersonViewModel
            {
                Person = _personRepository.GetPersonById(personId)
            };

            return this.View("index", model);
        }

        [HttpPost]
        public ActionResult Withdraw(PersonViewModel vm)
        {
            _personRepository.AddTransaction(vm.Person.Id, vm.WithdrawAmount);

            return RedirectToAction("index", new { personId = vm.Person.Id });
        }
    }
}