namespace Surrogat.Areas.CentralBank.Models
{
    using FluentNHibernate.Mapping;

    public class AcquirerBalanceMap : ClassMap<AcquirerBalanceBE>
    {
        public AcquirerBalanceMap()
        {
            this.Table("SG_CB_Akonto_Acquirer");
            this.Id(x => x.Id).Column("Id").GeneratedBy.Identity();
            this.Map(x => x.AcquirerId).Column("AcquirerId");
            this.Map(x => x.Saldo).Column("Saldo");
        }
    }

    public class AcquirerBalanceBE
    {
        public virtual int Id { get; set; }
        public virtual int AcquirerId { get; set; }
        public virtual decimal Saldo { get; set; }
    }
}