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

    public void DepositMoney(decimal amount)
    {
      var account = new BankAccount();

      account.Balance += amount;

      bankRepo.Update(account);
    }
  }
}
