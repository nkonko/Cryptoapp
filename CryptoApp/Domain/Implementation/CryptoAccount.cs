namespace Domain
{
  using System;
  using System.ComponentModel.DataAnnotations;

  public class CryptoAccount : IAccount
  {
    [Key]
    public Guid UUID { get; set; }

    public decimal Balance { get; set; }

    public Client Client { get; set; }

    public int NumClient { get; set; }

    public Enum.Type Type { get; set; }

    public void Deposit(decimal amount)
    {
      throw new NotImplementedException();
    }

    public void Transfer()
    {
      throw new NotImplementedException();
    }
  }
}
