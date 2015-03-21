using System;
using FluentNHibernate.Mapping;

namespace Surrogat.Areas.Person.Models
{
    public class PersonEBillMap : ClassMap<PersonEBillBE>
    {
        public PersonEBillMap()
        {
            this.Table("SG_P_EBill");
            this.Id(x => x.Id).Column("Id").GeneratedBy.Identity();
            Map(x => x.PersonId).Column("Person_FK");
            Map(x => x.Token).Column("Token");
            Map(x => x.Amount).Column("Amount");
            Map(x => x.WithdrawDate).Column("WithdrawDate");
            Map(x => x.Cashed).Column("Cashed");
            Map(x => x.CashedDate).Column("CashedDate");
        }
    }

    public class PersonEBillBE
    {
        public virtual int Id { get; set; }
        public virtual int PersonId { get; set; }
        public virtual Guid Token { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime WithdrawDate { get; set; }
        public virtual bool Cashed { get; set; }
        public virtual DateTime? CashedDate { get; set; }
    }
}


