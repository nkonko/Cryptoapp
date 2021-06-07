namespace CryptoApp.Controllers
{
  using System.Collections.Generic;
  using Domain;
  using Domain.Implementation;
  using Microsoft.AspNetCore.Mvc;
  using Services.Interface;

  [ApiController]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly IDepositService depositSvc;

    private readonly IAccountService accountSvc;

    public AccountController(IDepositService depositSvc, IAccountService accountSvc)
    {
      this.depositSvc = depositSvc;
      this.accountSvc = accountSvc;
    }

    [HttpPost]
    [Produces(typeof(IAccount))]
    public IActionResult Post(User account)
    {
      accountSvc.CreateAccount(account);

      return Ok();
    }

    [HttpGet]
    [Route("get/{id}")]
    [Produces(typeof(BankAccount))]
    public IActionResult GetArsAccount([FromRoute] int accountNumber)
    {
      var account = accountSvc.GetArsAccount(accountNumber);

      return Ok(account);
    }

    [HttpPut]
    [Route("Deposit/{id}")]

    public IActionResult Deposit([FromRoute]int accNumber, [FromBody]decimal amount)
    {
      var account = accountSvc.GetArsAccount(accNumber);

      depositSvc.DepositMoney(account, amount);

      return Ok();
    }
  }
}
