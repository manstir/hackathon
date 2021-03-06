﻿using System.Collections.Generic;
using Surrogat.Areas.Issuer.Models;

namespace Surrogat.Areas.Issuer.ViewModels
{
    public class IssuerViewModel
    {
        public int IssuerId { get; set; }
        public IReadOnlyCollection<AccountBE> Accounts { get; set; }
        public IReadOnlyCollection<BillBE> Bills { get; set; }
    }
}