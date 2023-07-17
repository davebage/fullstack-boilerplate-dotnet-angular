import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { TransactionRequestAPIModel } from './transaction-request-apimodel';
import { Transaction } from './transaction';

@Injectable({
  providedIn: 'root'
})
export class RESTAPIService {
  constructor(private http: HttpClient) { }

  createTransaction(transactionrequest: TransactionRequestAPIModel) {
    console.log("Posting");
    let url = "http://localhost:5000/transactions";

    this.http.post<Transaction>(url, transactionrequest).subscribe(
      data => {
        let temp = new Transaction(data.transaction_id, data.account_id, data.amount, data.created_at);
        console.log(temp.account_id + "|" + temp.transaction_id + "|" + temp.amount + "|" + temp.created_at);
        return temp;
     })
  };
}