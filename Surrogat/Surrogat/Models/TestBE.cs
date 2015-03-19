namespace Surrogat.Models
{
    using System;
    using System.Security.Cryptography.X509Certificates;

    using FluentNHibernate.Conventions.Helpers;
    using FluentNHibernate.Mapping;

    public class TestBE
    {
        public TestBE()
        {
            Id = Guid.NewGuid();
        }
        public virtual Guid Id { get; set; }
        public virtual string TestField { get; set; }
    }

    public class TestMap : ClassMap<TestBE>
    {
        public TestMap()
        {
            this.Table("SG_Test");
            this.Id(x => x.Id).Column("Id").GeneratedBy.Assigned();
            Map(x => x.TestField).Column("testfield");
        }
    }
}