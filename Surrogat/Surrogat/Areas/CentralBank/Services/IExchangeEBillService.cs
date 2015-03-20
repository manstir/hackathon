namespace Surrogat.Areas.CentralBank.Services
{
    using System.Collections.Generic;

    using Surrogat.Shared;

    public interface IExchangeEBillService
    {
        IEnumerable<BillDto> Exchange(IEnumerable<BillDto> bills, decimal targetAmount);
    }
}   