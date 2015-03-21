using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Surrogat.Areas.Acquirer.Models;

namespace Surrogat.Areas.Acquirer.ViewModel
{
    public class AcquirerViewModel
    {
        public IList<MerchantBE> Merchants { get; set; }
    }
}
