using Monster.DataAccess;
using Monster.Model.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Monster.UI.Data
{
    public class AccountDataService : IAccountDataService
    {
        private readonly Func<AccountContext> _contextCreator;

        public AccountDataService(Func<AccountContext> contextCreator) => _contextCreator = contextCreator;

        public void UpdateAccount(Account account)
        {
            using(var context = _contextCreator())
            {
                context.Accounts.AddOrUpdate(account);
                context.SaveChanges();
            }
        }
        
        public static bool DoesPlayerExistWithName(AccountContext context, string name)
        {
            var accounts = from account in context.Accounts
                           select account;

            foreach (var user in accounts)
            {
                if (user.Username == name)
                    return true;
            }
            return false;
        }

        public static Account GetAccountByName(AccountContext context, string name)
        {
            return (from account in context.Accounts
                    where account.Username == name
                    select account).Single();
        }

    }
}
