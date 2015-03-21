namespace Surrogat.Areas.CentralBank.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NHibernate.Linq;

    using Surrogat.Areas.CentralBank.Models;
    using Surrogat.Models;

    public class BillRepository : BaseRepo
    {
        public EBillBE CreateBill(decimal amount)
        {
            using (var transaction = Session.BeginTransaction())
            {
                var serial = (int)Session.Save(new EBillBE { Amount = amount, IssuedDate = DateTime.Now, Token = Guid.NewGuid(), });
                var bill = this.LoadBillInternal(serial);
                transaction.Commit();
                return bill;
            }
        }

        public IReadOnlyCollection<EBillBE> GetAllBills()
        {
            using (var transaction = Session.BeginTransaction())
            {
                var bills = Session.Query<EBillBE>().ToList();
                transaction.Commit();
                return bills;
            }
        }

        public decimal CashBill(Guid token)
        {
            using (var transaction = Session.BeginTransaction())
            {
                var bill = this.LoadBillByTokenInternal(token);
                bill.CashedDate = DateTime.Now;
                var value = bill.Amount;
                transaction.Commit();
                return value;
            }
        }

        public EBillBE GetBillByToken(Guid token)
        {
            using (var transaction = Session.BeginTransaction())
            {
                var bill = this.LoadBillByTokenInternal(token);
                transaction.Commit();
                return bill;
            }
        }

        private EBillBE LoadBillInternal(int serial)
        {
            return Session.Query<EBillBE>().FirstOrDefault(b => b.Serial == serial);
        }

        private EBillBE LoadBillByTokenInternal(Guid token)
        {
            return Session.Query<EBillBE>().FirstOrDefault(b => b.Token == token);
        }
    }
}