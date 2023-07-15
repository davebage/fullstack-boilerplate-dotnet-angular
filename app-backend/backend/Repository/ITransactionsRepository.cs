using System;
using backend.Models;

namespace backend.Repository;

public interface ITransactionsRepository
{
    Transaction AddTransaction(Guid accountId, int amount);
    Transaction[] GetAllTransactions();
    Transaction GetTransactionById(Guid transactionId);
    Account GetAllTransactionsForAccount(Guid accountId);
}