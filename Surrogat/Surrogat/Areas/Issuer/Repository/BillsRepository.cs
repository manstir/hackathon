using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using Surrogat.Areas.Issuer.Models;
using Surrogat.Models;

namespace Surrogat.Areas.Issuer.Controllers
{
    public class BillsRepository : BaseRepo
    {
        public IReadOnlyCollection<BillBE> GetBills()
        {
            using (var transaction = Session.BeginTransaction())
            {
                var bills = Session.Query<BillBE>().ToList();
                transaction.Commit();
                return bills;
            }
        }

        public void AddBill(BillBE bill)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(bill);
                transaction.Commit();
            }
        }

        public BillBE WithdrawBill(decimal amount)
        {
            using (var transaction = Session.BeginTransaction())
            {
                var bill = Session.Query<BillBE>().FirstOrDefault(be => be.Amount.Equals(amount));
                if (bill == null)
                {
                    throw new Exception("No bill available for this amount");
                }
                Session.Delete(bill);
                transaction.Commit();
                return bill;
            }
        }
    }
}