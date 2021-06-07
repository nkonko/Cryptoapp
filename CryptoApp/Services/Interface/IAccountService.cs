namespace Services.Interface
{
  using Domain;

  public interface IAccountService
  {
    void CreateAccount(BankAccount account);
  }
}
