using System;

namespace backend.Models;

public class Account
{
    public Guid account_id { get; private set; }
    public int balance { get; private set; }

    public Account(Guid accountId, int accountSum)
    {
        account_id = accountId;
        balance = accountSum;
    }
}