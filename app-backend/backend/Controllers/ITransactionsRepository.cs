using System;

namespace backend.Controllers;

public interface ITransactionsRepository
{
    Transaction AddTransaction(Guid accountId, int amount);
    Transaction[] GetAllTransactions();
    Transaction GetTransactionById(Guid transactionId);
    Account GetAllTransactionsForAccount(Guid accountId);
}