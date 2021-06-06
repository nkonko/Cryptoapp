using Data.Repository;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace CryptoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IRepository<Client> repository;

        public ClientController(IRepository<Client> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Produces(typeof(Client))]
        public IActionResult Post(Client client)
        {
            repository.Save(client);

            return Ok();
        }
    }
}
