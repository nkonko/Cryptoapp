namespace CryptoApp.Controllers
{
  using Domain;
  using Domain.Implementation;
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
    [Route("ArsToUsd")]
    [Produces(typeof(bool))]
    public IActionResult ExchangeArsToUsd([FromBody]ExchangeObj exchangeObj)
    {
      var amountd = decimal.Parse(exchangeObj.Amount);

      var result = exchangeSvc.ExchangeArsToUsd(int.Parse(exchangeObj.Id), amountd);

      return Ok(result);
    }

    [HttpPost]
    [Route("UsdToBtc")]
    [Produces(typeof(bool))]
    public IActionResult ExchangeUsdToBtc(int id, string amount)
    {
      var amountd = decimal.Parse(amount);

      var result = exchangeSvc.ExchangeUsdToBtc(id, amountd);

      return Ok(result);
    }
  }
}
