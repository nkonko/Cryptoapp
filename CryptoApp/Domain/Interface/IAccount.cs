using System.Collections.Generic;

namespace Domain
{
    public interface IAccount
    {
        decimal Balance { get; set; }

        Client Client { get; set; }

        List<Transaction> Transactions { get; set; }

        void Deposit(decimal amount);

        void Transfer();
    }
}
