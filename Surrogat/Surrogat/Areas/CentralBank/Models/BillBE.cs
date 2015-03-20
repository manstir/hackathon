namespace Surrogat.Areas.CentralBank.Models
{
    using System;

    using FluentNHibernate.Mapping;

    public class BillMap : ClassMap<BillBE>
    {
        public BillMap()
        {
            this.Table("SG_CB_Bill");
            this.Id(x => x.Serial).Column("Serial").GeneratedBy.Identity();
            Map(x => x.IssuedDate).Column("IssueDate");
            Map(x => x.CashedDate).Column("CashedDate");
            Map(x => x.Amount).Column("Amount");
            Map(x => x.Token).Column("Salt");
        }
    }
    public class BillBE
    {
        public virtual int Serial { get; set; }
        public virtual DateTime IssuedDate { get; set; }
        public virtual DateTime? CashedDate { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual Guid Token { get; set; }
    }
}