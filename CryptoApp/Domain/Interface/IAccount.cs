namespace Domain
{
    public interface IAccount
    {
        decimal Balance { get; set; }

        Client Client { get; set; }

        Transaction Transaction { get; set; }

        void Deposit();

        void Transfer();
    }
}
