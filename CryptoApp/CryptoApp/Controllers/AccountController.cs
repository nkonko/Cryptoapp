namespace CryptoApp.Controllers
{
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
      var id = accountSvc.CreateAccount(account);

      return Ok(id);
    }

    [HttpGet]
    [Route("get/{id}")]
    [Produces(typeof(BankAccount))]
    public IActionResult GetArsAccount([FromRoute] int id)
    {
      var account = accountSvc.GetArsAccount(id);

      return Ok(account);
    }

    [HttpPut]
    [Route("Deposit/{id}")]

    public IActionResult Deposit([FromRoute]int id, [FromBody]decimal amount)
    {
      var account = accountSvc.GetArsAccount(id);

      depositSvc.DepositMoney(account, amount);

      return Ok();
    }
  }
}
