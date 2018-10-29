using Monster.DataAccess;
using Monster.Model.Cryptation;
using Monster.Model.Models;
using Monster.UI.Data;
using System;

namespace Monster.UI.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly AccountContext context = new AccountContext();

        public Account AuthenticateUser(string username, string password)
        {
            Account account = new Account();
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
                    return account = null;

                if (AccountDataService.DoesPlayerExistWithName(context, username.ToLower()))
                {
                    account = AccountDataService.GetAccountByName(context, username.ToLower());

                    string saltedPassword = string.Concat(account.Salt, password);
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
