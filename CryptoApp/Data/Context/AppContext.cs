namespace Data
{
    using System;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class AppContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<BankAccount> Account { get; set; }

        public DbSet<CryptoAccount> CryptoAccount { get; set; }

        public DbSet<Client> Client { get; set; }

        public AppContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging()
                          .EnableDetailedErrors()
                          .LogTo(Console.WriteLine);
        }
    }
}
