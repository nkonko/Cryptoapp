namespace Services.Interface
{
  public interface IExchangeService
  {
    bool ExchangeArsToUsd(int id, decimal amount);

    bool ExchangeUsdToBtc(int id, decimal amount);
  }
}
