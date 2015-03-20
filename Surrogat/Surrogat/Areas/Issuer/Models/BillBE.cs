using System;
using FluentNHibernate.Mapping;

namespace Surrogat.Areas.Issuer.Models
{
    public class BillMap : ClassMap<BillBE>
    {
        public BillMap()
        {
            Table("SG_IS_Bill");
            Id(x => x.Id).Column("Id");
            Map(x => x.Token).Column("Token");
            Map(x => x.Amount).Column("Amount");
            Map(x => x.BoughtOn).Column("BoughtOn");
        }
    }

    public class BillBE
    {
        public virtual int Id { get; set; }
        public virtual string Token { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime BoughtOn { get; set; }}
}