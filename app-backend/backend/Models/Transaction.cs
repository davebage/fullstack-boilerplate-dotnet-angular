using System;

namespace backend.Models;

public class Transaction
{
    public Guid account_id { get; set; }
    public Guid transaction_id { get; set; }
    public int amount { get; set; }
    public DateTime created_at { get; set; }

}