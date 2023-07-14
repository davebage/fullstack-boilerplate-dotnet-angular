using System;

namespace backend.Controllers;

public class Transaction
{
    public Guid account_id;
    public Guid transaction_id;
    public int amount;
    public DateTime created_at;

}