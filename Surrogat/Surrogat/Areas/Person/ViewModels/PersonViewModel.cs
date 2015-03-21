using System.Linq;
using Surrogat.Areas.Person.Models;

namespace Surrogat.Areas.Person.ViewModels
{
    public class PersonViewModel
    {
        public PersonBE Person { get; set; }
        public decimal Amount { get; set; }
        public PersonEBillBE CashedEBill { get; set; }

        public string GetFullname()
        {
            return string.Concat(Person.Firstname, " ", Person.Lastname);
        }

        public decimal GetBalance()
        {
            return Person.EBills.Where(transaction => transaction.CashedDate == null).Sum(transaction => transaction.Amount);
        }

        public string GetQRCode()
        {
            return string.Concat(CashedEBill.Amount, "_", CashedEBill.Token);
        }
    }
}