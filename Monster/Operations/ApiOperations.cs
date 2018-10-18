using Monster.Login.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Monster
{
    class ApiOperations
    {
        private AccountContext context = new AccountContext();
        

        private string baseUrl;

        public ApiOperations()
        {
            baseUrl = "http://localhost:5000/api";
        }

        public Account AuthenticateUser(string username, string password)
        {
            Account account = new Account();

            try
            {
                if (Queries.DoesPlayerExistWithName(context, username))
                {
                    account = Queries.GetAccountByName(context, username);

                    string saltedPassword = string.Concat(account.Salt, password);
                    string hashedPassword = Hashing.ComputeSha256Hash(saltedPassword);

                    bool matchedPassword = string.Equals(account.PasswordHash, hashedPassword);

                    if (matchedPassword)
                    {
                        Globals.LoggedInUser = account;
                        NavigationService.Navigate(new DetailsPage());
                    }
                    else
                        MessageBox.Show("Username or password is incorrect");
                }
                else
                    MessageBox.Show("Username or password is incorrect");

            }
            catch (Exception)
            {
                throw;
            }

            string endpoint = baseUrl + "/users/login";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                username,
                password
            });

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                string response = wc.UploadString(endpoint, method, json);
                return JsonConvert.DeserializeObject<Account>(response);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Account GetUserDetails(Account user)
        {
            string endpoint = baseUrl + "/users/" + user.Id; 
            string access_token = user.AccessToken;

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = access_token;
            try
            {
                string response = wc.DownloadString(endpoint);
                user = JsonConvert.DeserializeObject<Account>(response);
                user.AccessToken = access_token;
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Account RegisterUser(string username, string password)
        {

            Account account = new Account(username, password);
            try
            {
                if (!Queries.DoesPlayerExistWithName(context, account.Username))
                {
                    context.Accounts.Add(account);
                    context.SaveChanges();

                    MessageBox.Show("Registration successful");
                    Globals.LoggedInUser = account;

                    NavigationService ns = NavigationService.GetNavigationService(new LoginPage());
                }
                else
                    MessageBox.Show("Username already exists");
            }
            catch (Exception)
            {
                throw;
            }

            string endpoint = baseUrl + "/users";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                account.Username,
                account.PasswordHash,
            });

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                string response = wc.UploadString(endpoint, method, json);
                return JsonConvert.DeserializeObject<Account>(response);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
