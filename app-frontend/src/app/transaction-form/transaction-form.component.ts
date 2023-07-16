import { NgForm } from '@angular/forms';
import { Component } from '@angular/core';
import { TransactionRequest } from '../transaction-request';
@Component({
  selector: 'app-transaction-form',
  templateUrl: './transaction-form.component.html',
  styleUrls: ['./transaction-form.component.css']
})
export class TransactionFormComponent {
  model = new TransactionRequest("","");
  submitted = false;
  onSubmit(transactionForm: NgForm) { 
    this.submitted = true;
    if(transactionForm.valid)
    {
      transactionForm.reset();
    }
  }
}
