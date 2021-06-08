namespace Services.Interface
{
  using Domain;

  public interface IDepositService
  {
    bool DepositMoney(BankAccount account, decimal amount);
  }
}
