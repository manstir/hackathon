using Surrogat.Areas.Person.Models;

namespace Surrogat.Areas.Person.ViewModels
{
    public class PersonViewModel
    {
        public PersonBE Person { get; set; }
        public decimal WithdrawAmount { get; set; }

        public string Fullname()
        {
            return string.Concat(Person.Firstname, " ", Person.Lastname);
        }
    }
}