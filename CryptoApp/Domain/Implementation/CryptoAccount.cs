namespace Domain
{
    using System;

    public class CryptoAccount : IAccount
    {
        public string UUID { get; set; }

        public decimal Balance { get; set; }

        public Client Client { get; set; }

        public Transaction Transaction { get; set; }

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
