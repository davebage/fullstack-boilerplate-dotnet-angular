import { Component, OnInit } from '@angular/core';
import { RESTAPIService } from './restapi.service';
import { Transaction } from './transaction';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app-frontend';
  public transactionList: Transaction[] = [];

  constructor(private service: RESTAPIService)
  {
  }

  ngOnInit(): void {
    this.onGetAllTransactions();
  }

  onGetAllTransactions() {
    this.service.getAllTransactions()
      .subscribe(data => {
        this.transactionList = data;
        
        this.getAccountBalance(this.transactionList[0]);
      });
  }

  getAccountBalance(transaction: Transaction) {
    if(!transaction) return;
    this.service.getAccountData(transaction.account_id).subscribe(data => transaction.accountBalance = data.balance);
  }

  onTransactionCreated(transaction: Transaction) {
    this.getAccountBalance(transaction);
    console.log("Ontransactioncreated:" + transaction.transaction_id);
    this.transactionList.unshift(transaction);
  }
}