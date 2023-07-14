using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly DateTimeProvider _dateTimeProvider;
        private readonly TransactionIdProvider _transactionIdProvider;
        private readonly List<Transaction> _transactions;

        public TransactionsRepository(DateTimeProvider dateTimeProvider, 
            TransactionIdProvider transactionIdProvider)
        {
            this._dateTimeProvider = dateTimeProvider;
            this._transactionIdProvider = transactionIdProvider;
            _transactions = new List<Transaction>();
        }

        public Transaction AddTransaction(Guid accountId, int amount)
        {
            Transaction transaction = new Transaction
            {
                account_id = accountId,
                amount = amount,
                created_at = _dateTimeProvider.UtcNow(),
                transaction_id = _transactionIdProvider.NewTransactionId()
            };

            _transactions.Add(transaction);
            return transaction;
        }

        public Transaction[] GetAllTransactions() => 
            _transactions.OrderByDescending(x => x.created_at).ToArray();

        public Transaction GetTransactionById(Guid transactionId) => 
            _transactions.FirstOrDefault(x => x.transaction_id == transactionId);
    }
}
