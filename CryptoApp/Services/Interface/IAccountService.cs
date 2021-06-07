namespace Services.Interface
{
  using Domain;
  using Domain.Implementation;

  public interface IAccountService
  {
    int CreateAccount(User userData);

    BankAccount GetArsAccount(int clientNumber);

    BankAccount GetUsdAccount(int clientNumber);

    CryptoAccount GetCryptoAccount(int clientNumber);
  }
}
