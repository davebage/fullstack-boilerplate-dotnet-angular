import { NgForm } from '@angular/forms';
import { Component } from '@angular/core';
import { TransactionRequest } from '../transaction-request';
import { RESTAPIService } from '../restapi.service';
import { TransactionRequestAPIModel } from '../transaction-request-apimodel';
@Component({
  selector: 'app-transaction-form',
  templateUrl: './transaction-form.component.html',
  styleUrls: ['./transaction-form.component.css']
})
export class TransactionFormComponent {
  model = new TransactionRequest("","");
  submitted = false;

  constructor(private service: RESTAPIService)
  {

  }

  onSubmit(transactionForm: NgForm) { 
    this.submitted = true;
    if(transactionForm.valid)
    {
      this.service.createTransaction(this.model.account_id, this.model.amount).subscribe(data => {
        console.log(data);
        transactionForm.reset();
      });
    }
  }
}