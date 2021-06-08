namespace Services.Implementation
{
  using Domain;
  using Services.Interface;

  public class TransferService : ITransferService
  {
    private readonly IAccountService accountService;

    public TransferService(IAccountService accountService)
    {
      this.accountService = accountService;
    }

    public bool MoneyTransfer(Domain.Enum.Type type, int sourceAccount, int targetAccount, decimal amount)
    {
      switch (type)
      {
        case Domain.Enum.Type.BTC:
          var sourceBtc = accountService.GetCryptoAccount(sourceAccount);
          var targetBtc = accountService.GetCryptoAccount(targetAccount);

          return Transfer(sourceBtc, targetBtc, amount);
        case Domain.Enum.Type.USD:
          var sourceUsd = accountService.GetUsdAccount(sourceAccount);
          var targetUsd = accountService.GetUsdAccount(targetAccount);

          return Transfer(sourceUsd, targetUsd, amount);
        case Domain.Enum.Type.ARS:
          var sourceArs = accountService.GetArsAccount(sourceAccount);
          var targetArs = accountService.GetArsAccount(targetAccount);

          return Transfer(sourceArs, targetArs, amount);
      }

      return false;
    }

    private bool Transfer(IAccount source, IAccount target, decimal amount)
    {
      if (source != null &&
          target != null &&
          source.Type == target.Type &&
          source.Balance <= amount)
      {
        source.Balance -= amount;
        target.Balance += amount;
        return true;
      }
      return false;
    }

  }
}
