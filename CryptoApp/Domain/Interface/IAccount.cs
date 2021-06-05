using System.Collections.Generic;

namespace Domain
{
    public interface IAccount
    {
        decimal Balance { get; set; }

        Client Client { get; set; }

        List<Transaction> Transaction { get; set; }

        void Deposit();

        void Transfer();
    }
}
