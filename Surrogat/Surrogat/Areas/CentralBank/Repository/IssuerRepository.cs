namespace Surrogat.Areas.CentralBank.Repository
{
    using System.Linq;

    using NHibernate.Linq;

    using Surrogat.Areas.CentralBank.Models;
    using Surrogat.Models;

    public class IssuerRepository : BaseRepo
    {
        public IssuerBalanceBE GetIssuerById(int issuerId)
        {
            using (var transaction = this.Session.BeginTransaction())
            {
                var issuer = this.GetIssuerInternal(issuerId);
                transaction.Commit();
                return issuer;
            }
        }

        public void UpdateIssuerBalance(int issuerId, decimal amount)
        {
            using (var transaction = this.Session.BeginTransaction())
            {
                var issuer = this.GetIssuerInternal(issuerId); 
                issuer.Saldi += amount;
                transaction.Commit();
            }
        }

        private IssuerBalanceBE GetIssuerInternal(int issuerId)
        {
            return this.Session.Query<IssuerBalanceBE>().FirstOrDefault(i => i.IssuerId == issuerId);
        }
    }
}