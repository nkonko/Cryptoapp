using Domain.Enum;

namespace Services.Interface
{
  public interface ITransferService
  {
    bool MoneyTransfer(Type type, int sourceAccount, int targetAccount, decimal amount);
  }
}
