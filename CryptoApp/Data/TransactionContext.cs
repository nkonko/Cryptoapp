namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class TransactionContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public TransactionContext(DbContextOptions options) : base(options)
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
