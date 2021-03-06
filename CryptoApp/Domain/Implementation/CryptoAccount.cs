namespace Domain
{
    using System;
    using System.Collections.Generic;

    public class CryptoAccount : IAccount
    {
        public Guid UUID { get; set; }

        public decimal Balance { get; set; }

        public Client Client { get; set; }

        public List<Transaction> Transaction { get; set; }

        public Enum.Type Type { get; set; }

        public void Deposit()
        {
            throw new NotImplementedException();
        }

        public void Transfer()
        {
            throw new NotImplementedException();
        }
    }
}
