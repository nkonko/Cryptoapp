using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Repository;
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

        private readonly IRepository<Transaction> repository;

        public TransactionController(ILogger<TransactionController> logger, IRepository<Transaction> repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return repository.List();
        }

        [HttpPost]
        
        public void Post(Transaction transaction)
        {
            repository.Save(transaction);
        }
    }
}
