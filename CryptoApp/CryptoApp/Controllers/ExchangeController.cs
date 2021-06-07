namespace CryptoApp.Controllers
{
  using Domain;
  using Microsoft.AspNetCore.Mvc;
  using Services.Interface;

  [ApiController]
  [Route("[controller]")]
  public class ExchangeController : ControllerBase
  {
    private readonly IExchangeService exchangeSvc;

    public ExchangeController(IExchangeService exchangeSvc)
    {
      this.exchangeSvc = exchangeSvc;
    }

    [HttpPost]
    [Produces(typeof(IAccount))]
    public IActionResult ExchangeArsToUsd(int id, string amount)
    {
      var amountd = decimal.Parse(amount);

      var result = exchangeSvc.ExchangeArsToUsd(id, amountd);

      return Ok(result);
    }

    [HttpPost]
    [Produces(typeof(IAccount))]
    public IActionResult ExchangeUsdToBtc(int id, string amount)
    {
      var amountd = decimal.Parse(amount);

      var result = exchangeSvc.ExchangeUsdToBtc(id, amountd);

      return Ok(result);
    }
  }
}
