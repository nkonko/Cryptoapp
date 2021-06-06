namespace CryptoApp.Controllers
{
    using Data.Repository;
    using Domain;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IRepository<IAccount> repository;

        public AccountController(IRepository<IAccount> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Produces(typeof(IAccount))]
        public IActionResult Post(IAccount account)
        {
            repository.Save(account);

            return Ok();
        }
    }
}
