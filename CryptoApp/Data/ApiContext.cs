namespace Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class ApiContext : DbContext
    {
        public DbSet<Transaction> transactions { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
            LoadTransactions();
        }

        public void LoadTransactions()
        {
            var transaction = new Transaction() { Amount = 0, Description="Gaby puto" };
            transactions.Add(transaction);
        }

        public List<Transaction> GetTransactions()
        {
            return transactions.Local.ToList();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
