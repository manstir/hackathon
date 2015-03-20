using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using NHibernate.Linq;
using Surrogat.Areas.Issuer.Models;
using Surrogat.Models;

namespace Surrogat.Areas.Issuer.Controllers
{
    public class AccountsRepository : BaseRepo
    {
        public static byte[] CreatePasswordHash(string password)
        {
            var hashGenerator = MD5.Create();
            var saltedPassword = "SIXHackathon2015" + password;

            return hashGenerator.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
        }

        public IReadOnlyCollection<AccountBE> GetAccounts()
        {
            using (var transaction = Session.BeginTransaction())
            {
                var accounts = Session.Query<AccountBE>().ToList();
                transaction.Commit();
                return accounts;
            }
        }

        public void AddAccount(AccountBE account)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(account);
                transaction.Commit();
            }
        }
    }
}