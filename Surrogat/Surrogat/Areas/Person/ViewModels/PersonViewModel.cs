using System.Linq;
using System.Web.Mvc;
using Surrogat.Areas.Person.Models;

namespace Surrogat.Areas.Person.ViewModels
{
    public class PersonViewModel
    {
        public PersonBE Person { get; set; }
        public decimal Amount { get; set; }
        public string CashedInToken { get; set; }

        public string GetFullname()
        {
            return string.Concat(Person.Firstname, " ", Person.Lastname);
        }

        public decimal GetBalance()
        {
            return Person.EBills.Where(transaction => !transaction.Cashed).Sum(transaction => transaction.Amount);
        }
    }
}