using System;
using System.Linq;
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

        public void AddTransaction(int personId, decimal amount)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(new TransactionBE
                {
                    PersonId = personId,
                    Amount = amount,
                    WithdrawDate = DateTime.Now,
                    EBillToken = new Guid().ToString()
                });
                transaction.Commit();
            }
        }
    }
}