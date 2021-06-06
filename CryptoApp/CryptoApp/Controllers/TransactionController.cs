namespace CryptoApp.Controllers
{
    using System.Collections.Generic;
    using Data.Repository;
    using Domain;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IRepository<Transaction> repository;

        public TransactionController(IRepository<Transaction> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("transactions")]
        [Produces(typeof(IEnumerable<Transaction>))]
        public IActionResult GetTransactions()
        {
            var transactions = repository.List();

            return Ok(transactions);
        }

        [HttpPost]
        [Produces(typeof(Transaction))]
        public IActionResult Post(Transaction transaction)
        {
            repository.Save(transaction);

            return Ok();
        }
    }
}
