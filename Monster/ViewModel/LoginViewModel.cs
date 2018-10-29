using Autofac;
using Monster.DataAccess;
using Monster.Model.Cryptation;
using Monster.Model.Models;
using Monster.UI.Data;
using Monster.UI.Startup;
using Monster.UI.View;
using System;
using System.Security;

namespace Monster.UI.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly AccountContext context = new AccountContext();
        public string Username { get; set; }
        public string Password { private get; set; }

        public Account AuthenticateUser()
        {
            Account account = new Account();
            try
            {
                if (string.IsNullOrEmpty(Username) || string.IsNullOrWhiteSpace(Username))
                    return account = null;

                if (AccountDataService.DoesPlayerExistWithName(context, Username.ToLower()))
                {
                    account = AccountDataService.GetAccountByName(context, Username.ToLower());

                    string saltedPassword = string.Concat(account.Salt, Password);
                    string hashedPassword = Hashing.ComputeSha256Hash(saltedPassword);

                    bool matchedPassword = string.Equals(account.PasswordHash, hashedPassword);

                    if (matchedPassword)
                    {
                        account.PasswordHash = hashedPassword;
                        Globals.LoggedInUser = account;
                        return account;
                    }
                    else
                    {
                        return account = null;
                    }
                }
                return account = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
