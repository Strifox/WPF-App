using Monster.DataAccess;
using Monster.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster.UI.Data
{
    public class AccountDataService
    {
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
