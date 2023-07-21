export class Transaction {
    transaction_id: string;
    account_id: string;
    amount: number;
    created_at: Date;
    accountBalance: number;

    constructor(transaction_id:string, account_id:string, amount: number, created_at:Date, accountBalance: number)
    {
        this.transaction_id = transaction_id;
        this.account_id = account_id;
        this.amount = amount;
        this.created_at = created_at;
        this.accountBalance = accountBalance;
    }
}