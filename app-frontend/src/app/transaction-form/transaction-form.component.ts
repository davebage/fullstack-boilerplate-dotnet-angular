import { NgForm } from '@angular/forms';
import { Component, EventEmitter, Output } from '@angular/core';
import { TransactionRequest } from '../transaction-request';
import { RESTAPIService } from '../restapi.service';
import { Transaction } from '../transaction';

@Component({
  selector: 'app-transaction-form',
  templateUrl: './transaction-form.component.html',
  styleUrls: ['./transaction-form.component.css']
})
export class TransactionFormComponent {
  @Output() transactionCreated = new EventEmitter<Transaction>();
  model = new TransactionRequest("","");

  constructor(private service: RESTAPIService)
  {
  }

  onSubmit(transactionForm: NgForm) { 
    if(transactionForm.valid)
    {
      this.service
        .createTransaction(this.model.account_id, this.model.amount)
        .subscribe(transaction => {
          transactionForm.reset();
          this.transactionCreated.emit(transaction);
        });
    }
  }
}