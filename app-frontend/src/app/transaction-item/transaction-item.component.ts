import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-transaction-item',
  templateUrl: './transaction-item.component.html',
  styleUrls: ['./transaction-item.component.css']
})
export class TransactionItemComponent implements OnInit {
  @Input("data-id") transactionId : number = 0;
  @Input("data-type") transactionType : string = "";
  @Input("data-account-id") accountId : string = "";
  @Input("data-amount") transactionAmount : number = 0;
  @Input("data-balance") accountBalance : string = "";

  public fromToAccount: string = "";
  
  ngOnInit(): void {
    this.fromToAccount = (this.transactionAmount < 0) ? "from" : "to"
  }
}
