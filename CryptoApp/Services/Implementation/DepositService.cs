namespace Services.Implementation
{
  using Data.Repository;
  using Domain;
  using Services.Interface;

  public class DepositService : IDepositService
  {
    private readonly IRepository<BankAccount> bankRepo;
    private readonly IRepository<CryptoAccount> cryptoRepo;

    public DepositService(IRepository<BankAccount> bankRepo, IRepository<CryptoAccount> cryptoRepo)
    {
      this.bankRepo = bankRepo;
      this.cryptoRepo = cryptoRepo;
    }

    public void DepositMoney(BankAccount account, decimal amount)
    {
      account.Balance += amount;

      bankRepo.Update(account);
    }

    public void DepositCrypto(CryptoAccount account, decimal amount)
    {
      account.Balance += amount;

      cryptoRepo.Update(account);
    }
  }
}
