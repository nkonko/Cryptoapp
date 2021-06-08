namespace Services.Implementation
{
  using Data.Repository;
  using Domain;
  using Services.Interface;

  public class WithdrawService : IWithdrawService
  {
    private readonly IRepository<BankAccount> bankRepo;
    private readonly IRepository<CryptoAccount> cryptoRepo;

    public WithdrawService(IRepository<BankAccount> bankRepo, IRepository<CryptoAccount> cryptoRepo)
    {
      this.bankRepo = bankRepo;
      this.cryptoRepo = cryptoRepo;
    }
    public void ExtractMoney(Domain.Enum.Type type, IAccount account, decimal amount)
    {
      account.Balance += amount;

      if (type == Domain.Enum.Type.BTC)
      {
        cryptoRepo.Update((CryptoAccount)account);
      }
      else
      {
        bankRepo.Update((BankAccount)account);
      }
    }

  }
}
