using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using Surrogat.Areas.Acquirer.Models;
using Surrogat.Models;

namespace Surrogat.Areas.Acquirer.Repository
{
    public class MerchantRepository : BaseRepo
    {
        public IList<MerchantBE> GetMerchants(int acquirerId)
        {
            using (var transaction = Session.BeginTransaction())
            {
                var merchants = Session.Query<MerchantBE>().Where(b => b.AcquirerId == acquirerId).ToList();
                transaction.Commit();
                return merchants;
            }
        }

        public MerchantBE GetMerchantById(int merchantId)
        {
            using (var transaction = Session.BeginTransaction())
            {
                var merchant = Session.Query<MerchantBE>()
                    .SingleOrDefault(p => p.Id == merchantId);
                transaction.Commit();
                return merchant;
            }
        }

        public void UpdateSaldo(int merchantId, decimal amount)
        {
            using (var transaction = Session.BeginTransaction())
            {
                var merchant = Session.Query<MerchantBE>()
                    .SingleOrDefault(p => p.Id == merchantId);
                merchant.Saldo += amount;

                transaction.Commit();
            }
        }
    }
}