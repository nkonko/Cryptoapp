namespace Domain
{
    using System.Collections.Generic;
    using Domain.Enum;

    public class BankAccount : IAccount
    {
        public int AccountNumb { get; set; }

        public int CBU { get; set; }

        public string Alias { get; set; }

        public decimal Balance { get; set; }

        public Client Client { get; set; }

        public List<Transaction> Transactions { get; set; }

        public Type Type { get; set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Transfer()
        {
            throw new System.NotImplementedException();
        }
    }
}
