import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { TransactionRequestAPIModel } from './transaction-request-apimodel';
import { Transaction } from './transaction';
import { Account } from './account';

@Injectable({
  providedIn: 'root'
})
export class RESTAPIService {
  constructor(private http: HttpClient) { }
  rootUrl = "http://localhost:5000";
  createTransaction(accountId: string, amount: number) {
    const transactionRequest = new TransactionRequestAPIModel(accountId, amount);
    let url = this.rootUrl + "/transactions";

    return this.http.post<Transaction>(url, transactionRequest);
  };

  getTransaction(transactionId: string) {
    let url = this.rootUrl + "/transactions/" + transactionId;
    return this.http.get<Transaction>(url);
  }

  getAllTransactions() {
    let url = this.rootUrl + "/transactions";
    return this.http.get<Transaction[]>(url);
  }

  getAccountData(accountId: string) {
    let url = this.rootUrl + "/accounts/" + accountId;
    return this.http.get<Account>(url);
  }
}