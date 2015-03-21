using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using NHibernate.Linq;
using Surrogat.Areas.Person.Models;
using Surrogat.Models;

namespace Surrogat.Areas.Person.Repository
{
    public class PersonRepository : BaseRepo
    {
        public PersonBE GetPersonById(int personId)
        {
            using (var transaction = Session.BeginTransaction())
            {
                var person = Session.Query<PersonBE>()
                    .SingleOrDefault(p => p.Id == personId);
                transaction.Commit();
                return person;
            }
        }

        public void AddEBill(int personId, decimal amount, Guid token)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(new PersonEBillBE
                {
                    PersonId = personId,
                    Amount = amount,
                    WithdrawDate = DateTime.Now,
                    Token = token
                });
                transaction.Commit();
            }
        }

        public PersonEBillBE GetEBillByToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            using (var transaction = Session.BeginTransaction())
            {
                var eBill = Session.Query<PersonEBillBE>()
                    .SingleOrDefault(b => b.Token == new Guid(token));
                transaction.Commit();
                return eBill;
            }
        }

        public void CashInBills(IEnumerable<Guid> tokens)
        {
            using (var transaction = Session.BeginTransaction())
            {
                var uncashedEBills = Session.QueryOver<PersonEBillBE>()
                     .Where(b => b.Token.IsIn((ICollection)tokens))
                     .List<PersonEBillBE>();

                foreach (var eBill in uncashedEBills)
                {
                    eBill.CashedDate = DateTime.Now;
                }

                transaction.Commit();
            }
        }
    }
}