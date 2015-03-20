namespace Surrogat.Areas.CentralBank.ViewModels
{
    using System.Collections.Generic;

    using Surrogat.Areas.CentralBank.Models;

    public class BillListViewModel
    {
        public IReadOnlyCollection<EBillBE> Bills { get; set; } 
    }
}