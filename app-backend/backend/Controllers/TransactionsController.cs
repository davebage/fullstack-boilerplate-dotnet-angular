using System;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsRepository _repository;

        public TransactionsController(ITransactionsRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        public IActionResult CreateTransaction(TransactionRequest request)
        {
            var transaction = _repository.AddTransaction(request.account_id, request.amount);

            var actionName = nameof(GetTransactionForId);
            var routeValues = new { transaction.transaction_id };
            return CreatedAtAction(actionName, routeValues, transaction);
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            var transactions = _repository.GetAllTransactions();

            return Ok(transactions);
        }

        [HttpGet]
        [Route("{transaction_id}")]
        public IActionResult GetTransactionForId(Guid transaction_id)
        {
            var transaction = _repository.GetTransactionById(transaction_id);
            if (transaction == null)
                return NotFound("Transaction not found");

            return Ok(transaction);
        }
    }
}
