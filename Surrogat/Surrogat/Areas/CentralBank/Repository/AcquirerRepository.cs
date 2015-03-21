namespace Surrogat.Areas.CentralBank.Repository
{
    using System.Linq;

    using NHibernate.Linq;

    using Models;
    using Surrogat.Models;

    public class AcquirerRepository : BaseRepo
    {
        public AcquirerBalanceBE GetAcquirerById(int acquirerId)
        {
            using (var transaction = this.Session.BeginTransaction())
            {
                var acquirer = this.GetAcquirerInternal(acquirerId);
                transaction.Commit();
                return acquirer;
            }
        }

        public void UpdateAcquirerBalance(int acquirerId, decimal amount)
        {
            using (var transaction = this.Session.BeginTransaction())
            {
                var acquirer = this.GetAcquirerInternal(acquirerId); 
                acquirer.Saldo += amount;
                transaction.Commit();
            }
        }

        private AcquirerBalanceBE GetAcquirerInternal(int acquirerId)
        {
            return this.Session.Query<AcquirerBalanceBE>().FirstOrDefault(i => i.AcquirerId == acquirerId);
        }
    }
}