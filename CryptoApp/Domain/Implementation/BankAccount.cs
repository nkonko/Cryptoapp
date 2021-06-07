namespace Domain
{
  using System.ComponentModel.DataAnnotations;
  using Domain.Enum;

  public class BankAccount : IAccount
  {
    [Key]
    public int? AccountNumb { get; set; }

    public long? CBU { get; set; }

    public string Alias { get; set; }

    public decimal Balance { get; set; }

    public Client Client { get; set; }

    public int NumClient { get; set; }

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
