using System;

namespace backend.Controllers;

public class TransactionIdProvider
{
    public Guid NewTransactionId() => 
        GetTransactionId();

    protected virtual Guid GetTransactionId() => 
        Guid.NewGuid();
}