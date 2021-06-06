namespace CryptoApp.Controllers
{
  using Data.Repository;
  using Domain_Model.Implementation;
  using Microsoft.AspNetCore.Mvc;

  [ApiController]
  [Route("[controller]")]
  public class PriceController : ControllerBase
  {
    private readonly IRepository<Currency> repository;

    public PriceController(IRepository<Currency> repository)
    {
      this.repository = repository;
    }

    [HttpPost]
    [Produces(typeof(Currency))]
    public IActionResult Post(Currency price)
    {
      repository.Save(price);

      return Ok();
    }
  }
}
