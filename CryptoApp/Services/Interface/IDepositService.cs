namespace Services.Interface
{
  using Domain;

  public interface IDepositService
  {
    void DepositMoney(BankAccount account, decimal amount);
  }
}
