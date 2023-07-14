using System;

namespace backend.Controllers;

public class TransactionRequest
{
    public Guid account_id;
    public int amount;
}