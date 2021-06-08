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
    private readonly IWithdrawService withdrawService;

    public AccountController(IDepositService depositSvc, IAccountService accountSvc, IWithdrawService withdrawService)
    {
      this.depositSvc = depositSvc;
      this.accountSvc = accountSvc;
      this.withdrawService = withdrawService;
    }

    [HttpPost]
    [Produces(typeof(int))]
    public IActionResult Post(User account)
    {
      var id = accountSvc.CreateAccount(account);

      return Ok(id);
    }

    [HttpGet]
    [Route("get/{id}")]
    [Produces(typeof(BankAccount))]
    public IActionResult GetArsAccount([FromRoute] string id)
    {
      var account = accountSvc.GetArsAccount(int.Parse(id));

      return Ok(account);
    }

    [HttpPut]
    [Route("Deposit/{id}")]
    [Produces(typeof(bool))]
    public IActionResult Deposit([FromRoute] int id, [FromBody] decimal amount)
    {
      var account = accountSvc.GetArsAccount(id);

     var result = depositSvc.DepositMoney(account, amount);

      return Ok(result);
    }

    [HttpPut]
    [Route("Extract/{id}")]
    [Produces(typeof(void))]
    public IActionResult Extract(int type, [FromRoute] int id, [FromBody] decimal amount)
    {
      var account = accountSvc.GetArsAccount(id);

      withdrawService.ExtractMoney((Domain.Enum.Type)type, account, amount);

      return Ok();
    }
  }
}
