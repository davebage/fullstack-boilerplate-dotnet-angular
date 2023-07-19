import { Component, OnInit } from '@angular/core';
import { Transaction } from '../transaction';
import { RESTAPIService } from '../restapi.service';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrls: ['./transaction-list.component.css']
})
export class TransactionListComponent implements OnInit {
  public transactionList: Transaction[] = [];

  ngOnInit(): void {
    this.getTransactions();  
  }

  constructor(private apiservice: RESTAPIService) { }

  getTransactions() {
    this.apiservice.getAllTransactions().subscribe(data => {
      this.parseTransactions(data);
      this.getAccountData(this.transactionList[0].account_id);
    });
  }

  getAccountData(accountId:string) {
    this.apiservice.getAccountData(accountId).subscribe(data =>
      {
        this.transactionList[0].accountBalance = data.balance;
      });
  }

  parseTransactions(data: Transaction[])
  {
    this.transactionList = data;
  }
}
