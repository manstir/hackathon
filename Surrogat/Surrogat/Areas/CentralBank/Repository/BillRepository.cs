﻿namespace Surrogat.Areas.CentralBank.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NHibernate.Linq;

    using Surrogat.Areas.CentralBank.Models;
    using Surrogat.Models;

    public class BillRepository : BaseRepo
    {
        public BillBE CreateBill(decimal amount)
        {
            using (var transaction = Session.BeginTransaction())
            {
                var serial = (int) Session.Save(new BillBE { Amount = amount, IssuedDate = DateTime.Now, Token = Guid.NewGuid(), });
                var bill = this.LoadBillInternal(serial);
                transaction.Commit();
                return bill;
            }
        }

        public IReadOnlyCollection<BillBE> GetAllBills()
        {
            using (var transaction = Session.BeginTransaction())
            {
                var bills = Session.Query<BillBE>().Where(b => b.Serial < 100).ToList();
                transaction.Commit();
                return bills;
            }
        }

        private BillBE LoadBillInternal(int serial)
        {
            return  Session.Query<BillBE>().FirstOrDefault(b => b.Serial == serial);
        }
    }
}
