namespace CryptoApp.Controllers
{
  using Domain;
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
    public IActionResult Post(BankAccount account)
    {
      accountSvc.CreateAccount(account);

      return Ok();
    }

    [HttpPut]
    [Route("Deposit/{id}")]

    public IActionResult Deposit([FromBody]decimal amount)
    {
      depositSvc.DepositMoney(amount);

      return Ok();
    }
  }
}
