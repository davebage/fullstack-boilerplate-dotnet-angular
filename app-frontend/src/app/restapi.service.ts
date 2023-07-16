import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { TransactionRequestAPIModel } from './transaction-request-apimodel';
import { Transaction } from './transaction';

@Injectable({
  providedIn: 'root'
})
export class RESTAPIService {
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  postTransaction(transactionrequest: TransactionRequestAPIModel) {
    console.log("Posting");
    let url = "http://localhost:3000/transaction";
    this.http.post<TransactionRequestAPIModel>(url, transactionrequest, this.httpOptions);

    this.http.post<Transaction>(url, transactionrequest).subscribe(data => {
      let temp = new Transaction(data.transaction_id, data.account_id, data.amount, data.created_at);
      return temp;
  })


  }
}
