using FluentNHibernate.Mapping;

namespace Surrogat.Areas.Acquirer.Models
{
    public class MerchantMap : ClassMap<MerchantBE>
    {
        public MerchantMap()
        {
            this.Table("SG_AC_Merchant");
            this.Id(x => x.Id).Column("Id").GeneratedBy.Identity();
            Map(x => x.AcquirerId).Column("AcquirerId_FK");
            Map(x => x.Name).Column("Name");
            Map(x => x.Saldo).Column("Saldo");
        }
    }

    public class MerchantBE
    {
        public virtual int Id { get; set; }
        public virtual int AcquirerId { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Saldo { get; set; }
    }
}