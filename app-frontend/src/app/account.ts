export class Account {
    account_id: string;
    balance: number;

    constructor(account_id: string, balance: number)
    {
        this.account_id = account_id;
        this.balance = balance;
    }
}
