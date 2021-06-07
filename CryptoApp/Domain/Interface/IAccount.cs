namespace Domain
{
  public interface IAccount
  {
    decimal Balance { get; set; }

    Client Client { get; set; }

    public Enum.Type Type { get; set; }

    void Deposit(decimal amount);

    void Transfer();
  }
}
