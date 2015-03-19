namespace Surrogat.Models
{
    using System;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate;

    public class BaseRepo : IDisposable
    {
        public ISession Session;

        public BaseRepo()
        {
            var sessionFactory = CreateSessionFactory();
            this.Session = sessionFactory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2008
              .ConnectionString("Server=tcp:s9vjvqrycz.database.windows.net,1433;Database=fro;User ID=flo@s9vjvqrycz;Password=Fr0r1der-;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"))
              .Mappings(m =>
                m.FluentMappings.AddFromAssemblyOf<TestBE>())
              .BuildSessionFactory();
        }

        public void Dispose()
        {
            Session.Dispose();
        }
    }

    public class TestRepository : BaseRepo
    {
        public Guid InsertEntry(TestBE test)
        {
            using (var transaction = this.Session.BeginTransaction())
            {
                Session.Save(test);
                transaction.Commit();
                return test.Id;
            }
        }
    }
}