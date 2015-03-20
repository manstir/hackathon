using FluentNHibernate.Mapping;

namespace Surrogat.Areas.Issuer.Models
{
    public class AccountMap : ClassMap<AccountBE>
    {
        public AccountMap()
        {
            Table("SG_IS_Account");
            Id(x => x.Id).Column("Id");
            Map(x => x.Name).Column("Name");
            Map(x => x.Alias).Column("Alias");
            Map(x => x.PasswordHash).Column("PasswordHash");
            Map(x => x.Debt).Column("Debt");
        }
    }

    public class AccountBE
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Alias { get; set; }
        public virtual byte[] PasswordHash { get; set; }
        public virtual decimal Debt { get; set; }
    }
}