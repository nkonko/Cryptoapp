namespace Services.Implementation
{
  using Services.Interface;

  public class ExchangeService : IExchangeService
  {
    private readonly IAccountService accountSvc;
    private readonly  int dolarPrice = 165;
    private readonly  int bitcoinPrice = 43000;
    public ExchangeService(IAccountService accountSvc)
    {
      this.accountSvc = accountSvc;
    }

    public bool ExchangeArsToUsd(int id, decimal amount)
    {
      var accountArs = accountSvc.GetArsAccount(id);
      var accountUsd = accountSvc.GetUsdAccount(id);

      accountArs.Balance -= amount;
      accountUsd.Balance = amount / dolarPrice;

      return true;
    }

    public bool ExchangeUsdToBtc(int id, decimal amount)
    {
      var accountUsd = accountSvc.GetUsdAccount(id);
      var accountBtc = accountSvc.GetCryptoAccount(id);

      accountUsd.Balance -= amount;
      accountBtc.Balance = amount / bitcoinPrice;

      return true;
    }
  }
}
