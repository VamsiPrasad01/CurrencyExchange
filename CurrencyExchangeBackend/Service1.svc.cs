using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;

namespace CurrencyExchangeBackend
{
    public class Service1 : IService1
    {
        private static double userPLNBalance = 1000.0;
        private static Dictionary<string, double> userCurrencies = new Dictionary<string, double>();

        public double GetExchangeRate(string currencyCode)
        {
            string url = $"https://api.nbp.pl/api/exchangerates/rates/a/{currencyCode}?format=json";
            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString(url);
                JObject data = JObject.Parse(response);
                return (double)data["rates"][0]["mid"];
            }
        }

        public string BuyCurrency(string currencyCode, double plnAmount)
        {
            using (var db = new ExchangeDbContext())
            {
                // Simulate a single logged-in user
                var user = db.Users.Include("Wallets").FirstOrDefault(u => u.Id == 1);
                if (user == null)
                {
                    user = new User { Username = "DefaultUser", PLNBalance = 1000 };
                    db.Users.Add(user);
                    db.SaveChanges();
                }

                if (user.PLNBalance < plnAmount)
                    return "Insufficient PLN balance.";

                double rate = GetExchangeRate(currencyCode);
                double currencyAmount = plnAmount / rate;

                // Deduct PLN
                user.PLNBalance -= plnAmount;

                // Add to wallet
                var wallet = user.Wallets?.FirstOrDefault(w => w.CurrencyCode == currencyCode.ToLower());
                if (wallet == null)
                {
                    wallet = new Wallet { CurrencyCode = currencyCode.ToLower(), Amount = 0, UserId = user.Id };
                    db.Wallets.Add(wallet);
                }
                wallet.Amount += currencyAmount;

                // Log transaction
                db.Transactions.Add(new Transaction
                {
                    Type = "Buy",
                    CurrencyCode = currencyCode,
                    Amount = currencyAmount,
                    Timestamp = DateTime.Now,
                    UserId = user.Id
                });

                db.SaveChanges();

                return $"Bought {currencyAmount:F2} {currencyCode.ToUpper()}. New PLN balance: {user.PLNBalance:F2}";
            }
        }
        public string SellCurrency(string currencyCode, double currencyAmount)
        {
            using (var db = new ExchangeDbContext())
            {
                var user = db.Users.Include("Wallets").FirstOrDefault(u => u.Id == 1);
                if (user == null)
                    return "User not found.";

                var wallet = user.Wallets?.FirstOrDefault(w => w.CurrencyCode == currencyCode.ToLower());
                if (wallet == null || wallet.Amount < currencyAmount)
                    return "Insufficient currency balance.";

                double rate = GetExchangeRate(currencyCode);
                double plnAmount = currencyAmount * rate;

                wallet.Amount -= currencyAmount;
                user.PLNBalance += plnAmount;

                db.Transactions.Add(new Transaction
                {
                    Type = "Sell",
                    CurrencyCode = currencyCode,
                    Amount = currencyAmount,
                    Timestamp = DateTime.Now,
                    UserId = user.Id
                });

                db.SaveChanges();

                return $"Sold {currencyAmount:F2} {currencyCode.ToUpper()}. New PLN balance: {user.PLNBalance:F2}";
            }
        }
        public double GetPLNBalance()
        {
            using (var db = new ExchangeDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == 1);
                return user?.PLNBalance ?? 0;
            }
        }
        public Dictionary<string, double> GetCurrencyHoldings()
        {
            using (var db = new ExchangeDbContext())
            {
                var user = db.Users.Include("Wallets").FirstOrDefault(u => u.Id == 1);
                if (user?.Wallets == null) return new Dictionary<string, double>();

                return user.Wallets.ToDictionary(w => w.CurrencyCode.ToUpper(), w => w.Amount);
            }
        }


    }
}
