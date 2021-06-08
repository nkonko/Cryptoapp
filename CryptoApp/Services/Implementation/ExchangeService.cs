namespace Services.Implementation
{
  using Data.Repository;
  using Domain;
  using Services.Interface;

  public class ExchangeService : IExchangeService
  {
    private readonly IAccountService accountSvc;
    private readonly IRepository<BankAccount> repository;
    private readonly IRepository<CryptoAccount> cryptoRepo;

    private readonly int dolarPrice = 165;
    private readonly int bitcoinPrice = 43000;
    public ExchangeService(IAccountService accountSvc, IRepository<BankAccount> repository, IRepository<CryptoAccount> cryptoRepo)
    {
      this.accountSvc = accountSvc;
      this.repository = repository;
      this.cryptoRepo = cryptoRepo;
    }

    public bool ExchangeArsToUsd(int id, decimal amount)
    {
      var accountArs = accountSvc.GetArsAccount(id);
      var accountUsd = accountSvc.GetUsdAccount(id);

      if (accountArs.Balance >= amount)
      {
        accountArs.Balance -= amount;
        accountUsd.Balance = amount / dolarPrice;

        repository.Update(accountArs);
        repository.Update(accountUsd);
        return true;
      }

      return false;
    }

    public bool ExchangeUsdToBtc(int id, decimal amount)
    {
      var accountUsd = accountSvc.GetUsdAccount(id);
      var accountBtc = accountSvc.GetCryptoAccount(id);

      accountUsd.Balance -= amount;
      accountBtc.Balance = amount / bitcoinPrice;

      repository.Update(accountUsd);
      cryptoRepo.Update(accountBtc);

      return true;
    }
  }
}
