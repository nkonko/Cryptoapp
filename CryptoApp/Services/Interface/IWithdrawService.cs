namespace Services.Interface
{
  using Domain;
  using Domain.Enum;

  public interface IWithdrawService
  {
    void ExtractMoney(Type type, IAccount account, decimal amount);
  }
}
