namespace Surrogat.Areas.CentralBank.Services
{
    using System.Collections.Generic;

    using Surrogat.Shared;

    public class ExchangeEBillService : IExchangeEBillService
    {
        public List<BillDto> Exchange(IEnumerator<BillDto> bills, decimal targetAmount)
        {
            throw new System.NotImplementedException();
        }
    }
}