namespace CryptoAppTest
{
  using System.Collections.Generic;
  using Data.Repository;
  using Domain;
  using Domain.Implementation;
  using Moq;
  using NUnit.Framework;
  using Services.Implementation;

  [TestFixture]
  public class AccountTest
  {
    private Mock<IRepository<BankAccount>> mockBankRepo;
    private Mock<IRepository<CryptoAccount>> mockCryptoRepo;
    private AccountService service;

    [SetUp]
    public void Setup()
    {
      mockBankRepo = new Mock<IRepository<BankAccount>>();
      mockCryptoRepo = new Mock<IRepository<CryptoAccount>>();
      service = new AccountService(mockBankRepo.Object, mockCryptoRepo.Object);
    }

    [Test]
    public void CreateAccountTest()
    {
      mockBankRepo.Setup(x => x.List()).Returns(new List<BankAccount>());
      mockBankRepo.Setup(x => x.Save(new BankAccount()));
      mockCryptoRepo.Setup(x => x.List()).Returns(new List<CryptoAccount>());
      mockCryptoRepo.Setup(x => x.Save(new CryptoAccount()));

      var result = service.CreateAccount(new User() { Alias = "Test", dni = "10000000", Name = "Test" });

      Assert.IsInstanceOf<int>(result);
    }
  }
}
