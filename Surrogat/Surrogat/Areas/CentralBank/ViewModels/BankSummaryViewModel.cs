namespace Surrogat.Areas.CentralBank.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class BankSummaryViewModel
    {
        public IReadOnlyCollection<Int32> IssuerIds { get; set; } 
        public IReadOnlyCollection<Int32> AcquirerIds { get; set; } 
    }
}