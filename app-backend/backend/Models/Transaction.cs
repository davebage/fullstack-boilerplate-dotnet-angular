using System;

namespace backend.Models;

public class Transaction
{
    public Guid account_id;
    public Guid transaction_id;
    public int amount;
    public DateTime created_at;

}