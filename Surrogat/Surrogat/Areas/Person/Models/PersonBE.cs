using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace Surrogat.Areas.Person.Models
{
    public class PersonMap : ClassMap<PersonBE>
    {
        public PersonMap()
        {
            this.Table("SG_P_Person");
            this.Id(x => x.Id).Column("Id").GeneratedBy.Identity();
            Map(x => x.Firstname).Column("Firstname");
            Map(x => x.Lastname).Column("Lastname");
            Map(x => x.Email).Column("Email");
            HasMany(x => x.EBills).KeyColumn("Person_FK");
        }
    }

    public class PersonBE
    {
        public PersonBE()
        {
            EBills = new List<PersonEBillBE>();
        }  

        public virtual int Id { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Email { get; set; }
        public virtual IList<PersonEBillBE> EBills { get; set; }
    }
}
