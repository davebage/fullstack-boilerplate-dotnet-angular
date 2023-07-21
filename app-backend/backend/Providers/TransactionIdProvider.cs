using System;

namespace backend.Providers;

public class TransactionIdProvider
{
    public Guid NewTransactionId() =>
        GetTransactionId();

    protected virtual Guid GetTransactionId() =>
        Guid.NewGuid();
}