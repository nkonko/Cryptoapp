namespace Services.Implementation
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Data.Repository;
  using Domain;
  using Domain.Implementation;
  using RandomDataGenerator.FieldOptions;
  using RandomDataGenerator.Randomizers;
  using Services.Exceptions;
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

    public int CreateAccount(User userData)
    {
      try
      {
        var repoB = bankRepo.List().ToList();
        var repoC = cryptoRepo.List().ToList();

        if (repoB.Count == 0 && repoC.Count == 0)
        {
          var client = new Client() { Dni = userData.dni, Name = userData.Name, Transactions = new List<Transaction>() };

          client = GenerateStandarAccount(client, userData.Alias, repoB);

          var cryptoAccount = new CryptoAccount()
          {
            Balance = 0,
            Client = client,
            Type = Domain.Enum.Type.BTC,
            UUID = new Guid()
          };

          cryptoRepo.Save(cryptoAccount);

          return client.NumClient.Value;
        }
        else
        {
          throw new ClientException("El cliente ya existe.");
        }

      }
      catch (Exception ex)
      {
        //TODO: Add logger and send ex message
        throw new Exception($"hubo un error: {ex}");
      }
    }

    public BankAccount GetArsAccount(int clientNumber)
    {
      return bankRepo.Where(acc => acc.NumClient == clientNumber &&
                            acc.Type == Domain.Enum.Type.ARS).FirstOrDefault();
    }

    public BankAccount GetUsdAccount(int clientNumber)
    {
      return bankRepo.Where(acc => acc.NumClient == clientNumber &&
                            acc.Type == Domain.Enum.Type.USD).FirstOrDefault();
    }

    public CryptoAccount GetCryptoAccount(int clientNumber)
    {
      return cryptoRepo.Where(acc => acc.NumClient == clientNumber &&
                              acc.Type == Domain.Enum.Type.BTC).FirstOrDefault();
    }

    private Client GenerateStandarAccount(Client client, string alias, List<BankAccount> repo)
    {
      int? arsAccNumber;
      int? usdAccNumber;

      do
      {
        arsAccNumber = GetAccountNumber(repo);

        usdAccNumber = GetAccountNumber(repo);
      }
      while (arsAccNumber == usdAccNumber);

      long? cbu = GetCbuNumber(repo);

      client.NumClient = arsAccNumber;

      var bankAccountArs = new BankAccount()
      {
        CBU = cbu,
        AccountNumb = arsAccNumber,
        NumClient = arsAccNumber.Value,
        Alias = alias,
        Balance = 0,
        Client = client,
        Type = Domain.Enum.Type.ARS
      };

      var bankAccountUsd = new BankAccount()
      {
        CBU = cbu,
        AccountNumb = usdAccNumber,
        NumClient = arsAccNumber.Value,
        Alias = alias,
        Balance = 0,
        Client = client,
        Type = Domain.Enum.Type.USD
      };

      bankRepo.Save(bankAccountArs);
      bankRepo.Save(bankAccountUsd);

      return client;
    }

    private static long? GetCbuNumber(List<BankAccount> repo)
    {
      long? cbu;
      do
      {
        cbu = RandomizerFactory.GetRandomizer(new FieldOptionsLong() { UseNullValues = false, Min = 111999999999999999 }).Generate();
      }
      while (repo.Any(acc => acc.CBU == cbu));
      return cbu;
    }

    private static int? GetAccountNumber(List<BankAccount> repo)
    {
      int? accNumber;
      do
      {
        accNumber = RandomizerFactory.GetRandomizer(new FieldOptionsInteger() { UseNullValues = false, Min = 400, Max = 5000 }).Generate();
      }
      while (repo.Any(acc => acc.AccountNumb == accNumber));
      return accNumber;
    }
  }
}
