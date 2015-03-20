namespace Surrogat.Areas.CentralBank.Models
{
    using FluentNHibernate.Mapping;

    public class IssuerBalanceBE
    {
        public virtual int Id { get; set; }
        public virtual int IssuerId { get; set; }
        public virtual decimal Saldi { get; set; }
    }

    public class IssuerBalanceMap : ClassMap<IssuerBalanceBE>
    {
        public IssuerBalanceMap()
        {
            this.Table("SG_CB_AKONTO_ISSUER");
            this.Id(x => x.Id).Column("Id").GeneratedBy.Identity();
            this.Map(x => x.IssuerId).Column("IssuerId");
            this.Map(x => x.Saldi).Column("saldi");
        }
    }
}