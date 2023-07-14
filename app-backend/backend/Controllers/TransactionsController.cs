using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateTransaction()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{transaction_id}")]
        public IActionResult GetTransactionForId(Guid transaction_id)
        {
            return NotFound("Transaction not found");
        }
    }
}
