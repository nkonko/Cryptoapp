namespace Services.Implementation
{
  using Data.Repository;
  using Domain;
  using Services.Interface;

  public class AccountService : IAccountService
  {
    private readonly IRepository<BankAccount> bankRepo;
    private readonly IRepository<CryptoAccount> cryptoRepo;

    public AccountService(IRepository<BankAccount> bankRepo, IRepository<CryptoAccount> cryptoRepo)
    {
      this.bankRepo = bankRepo;
      this.cryptoRepo = cryptoRepo;
    }

    public void CreateAccount(BankAccount account)
    {
      bankRepo.Save(account);
    }
  }
}
