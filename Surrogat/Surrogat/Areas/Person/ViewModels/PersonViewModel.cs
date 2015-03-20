using System.Linq;
using Surrogat.Areas.Person.Models;

namespace Surrogat.Areas.Person.ViewModels
{
    public class PersonViewModel
    {
        public PersonBE Person { get; set; }
        public decimal WithdrawAmount { get; set; }

        public string GetFullname()
        {
            return string.Concat(Person.Firstname, " ", Person.Lastname);
        }

        public decimal GetBalance()
        {
            return Person.Transactions.Where(transaction => !transaction.Cashed).Sum(transaction => transaction.Amount);
        }
    }
}