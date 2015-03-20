namespace Surrogat.Areas.CentralBank.Services
{
    using System.Collections.Generic;

    using Surrogat.Shared;

    public interface IExchangeEBillService
    {
        List<BillDto> Exchange(IEnumerator<BillDto> bills, decimal targetAmount);
    }
}