namespace Services.Implementation
{
  using Data.Repository;
  using Domain;
  using Services.Interface;

  public class DepositService : IDepositService
  {
    private readonly IRepository<BankAccount> bankRepo;

    public DepositService(IRepository<BankAccount> bankRepo)
    {
      this.bankRepo = bankRepo;
    }

    public bool DepositMoney(BankAccount account, decimal amount)
    {
      account.Balance += amount;

      bankRepo.Update(account);

      return true;
    }
  }
}
