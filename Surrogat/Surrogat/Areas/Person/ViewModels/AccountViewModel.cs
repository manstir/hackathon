using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogat.Areas.Person.Models;

namespace Surrogat.Areas.Person.ViewModels
{
    public class AccountViewModel
    {
        public PersonBE Person { get; set; }
        public decimal WithdrawAmount { get; set; }

        public string Fullname()
        {
            return string.Concat(Person.Firstname, " ", Person.Lastname);
        }
    }
}