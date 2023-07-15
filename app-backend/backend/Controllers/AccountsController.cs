using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ITransactionsRepository _repository;

        public AccountsController(ITransactionsRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Returns the account data
        /// </summary>
        /// <param name="account_id"></param>
        /// <returns></returns>
        [HttpGet]
        
        [Route("{account_id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAccountData(Guid account_id)
        {
            var accountData = _repository.GetAllTransactionsForAccount(account_id);

            if (accountData == null)
            {
                return NotFound("Account not found");
            }

            return Ok(accountData);
        }
    }
}
