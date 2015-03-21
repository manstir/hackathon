using System;

namespace Surrogat.Areas.CentralBank.Services
{
    using System.Collections.Generic;
    using Shared;

    public interface IExchangeEBillService
    {
        IEnumerable<BillDto> Exchange(IEnumerable<Guid> bills, decimal targetAmount);
    }
}   