namespace CryptoApp.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using Services.Interface;

  [ApiController]
  [Route("[controller]")]
  public class TransfersController : ControllerBase
  {

    private readonly ITransferService transferService;

    public TransfersController(ITransferService transferService)
    {
      this.transferService = transferService;
    }

    [HttpPost]
    [Route("transfer")]
    [Produces(typeof(bool))]
    public IActionResult Transfer(int type, int sourceAccount, int targetAccount, decimal amount)
    {
      var result = transferService.MoneyTransfer((Domain.Enum.Type)type,sourceAccount,targetAccount,amount);

      return Ok(result);
    }
  }
}
