using System;

namespace backend.Controllers;

public class Account
{
    public Guid account_id;
    public int balance;

    public Account(Guid accountId, int accountSum)
    {
        this.account_id = accountId;
        this.balance = accountSum;
    }
}