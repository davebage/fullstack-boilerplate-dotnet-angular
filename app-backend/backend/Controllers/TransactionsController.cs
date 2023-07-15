using System;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Creates a new transaction
        /// </summary>
        /// <param name="request">TransactionRequest object</param>
        /// <returns>Created transaction</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        public IActionResult CreateTransaction(TransactionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var transaction = _repository.AddTransaction(request.account_id, request.amount);

            var actionName = nameof(GetTransactionForId);
            var routeValues = new { transaction.transaction_id };
            return CreatedAtAction(actionName, routeValues, transaction);
        }

        /// <summary>
        /// Get transactions
        /// </summary>
        /// <returns>Transaction array</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetTransactions()
        {
            var transactions = _repository.GetAllTransactions();

            return Ok(transactions);
        }

        /// <summary>
        /// Returns the transaction by id
        /// </summary>
        /// <param name="transaction_id">GUID transaction Id</param>
        /// <returns>Transaction object</returns>
        [HttpGet]
        [Route("{transaction_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTransactionForId(Guid transaction_id)
        {
            var transaction = _repository.GetTransactionById(transaction_id);
            if (transaction == null)
                return NotFound("Transaction not found");

            return Ok(transaction);
        }
    }
}
