namespace Surrogat.Models
{
    using System;

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