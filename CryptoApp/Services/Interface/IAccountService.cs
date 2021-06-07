namespace Services.Interface
{
  using Domain;
  using Domain.Implementation;

  public interface IAccountService
  {
    void CreateAccount(User userData);

    BankAccount GetArsAccount(int accountNumber);

    BankAccount GetUsdAccount(int accountNumber);

    CryptoAccount GetCryptoAccount(int accountNumber);
  }
}
