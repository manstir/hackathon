namespace Surrogat.Areas.CentralBank.Repository
{
    using System.Collections.Generic;
    using System.Linq;

    using NHibernate.Linq;

    using Surrogat.Areas.CentralBank.Models;
    using Surrogat.Models;

    public class BillRepository : BaseRepo
    {
        public IReadOnlyCollection<BillBE> GetAllBills()
        {
                using (var transaction = Session.BeginTransaction())
                {
                    var bills =  Session.Query<BillBE>().Where(b => b.Serial < 100).ToList();
                    transaction.Commit();
                    return bills;
                }
        }    
    }
}