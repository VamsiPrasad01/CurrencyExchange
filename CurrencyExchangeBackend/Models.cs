using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CurrencyExchangeBackend
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public double PLNBalance { get; set; }

        public virtual ICollection<Wallet> Wallets { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }

    public class Wallet
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public double Amount { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

    public class Transaction
    {
        public int Id { get; set; }
        public string Type { get; set; } // "Buy" or "Sell"
        public string CurrencyCode { get; set; }
        public double Amount { get; set; }
        public DateTime Timestamp { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

    public class ExchangeDbContext : DbContext
    {
        public ExchangeDbContext() : base("name=ExchangeDb") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
