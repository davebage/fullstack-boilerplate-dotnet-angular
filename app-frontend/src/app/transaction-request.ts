export class TransactionRequest {
    account_id: string;
    amount: number;

    constructor(account_id: string, amount: number)
    {
        this.account_id = account_id;
        this.amount = amount;
    }
}
