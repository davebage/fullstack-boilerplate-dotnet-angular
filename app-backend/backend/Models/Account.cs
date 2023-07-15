using System;

namespace backend.Models;

public class Account
{
    public Guid account_id;
    public int balance;

    public Account(Guid accountId, int accountSum)
    {
        account_id = accountId;
        balance = accountSum;
    }
}