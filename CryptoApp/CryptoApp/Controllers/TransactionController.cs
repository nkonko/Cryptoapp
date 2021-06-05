using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CryptoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;

        private readonly ApiContext apiContext;

        public TransactionController(ILogger<TransactionController> logger, ApiContext apiContext)
        {
            _logger = logger;
            this.apiContext = apiContext;
        }

        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            var transactions = apiContext.GetTransactions();
            return transactions;
        }
    }
}
