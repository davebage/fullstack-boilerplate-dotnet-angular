import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransactionFormComponent } from './transaction-form.component';
import { RESTAPIService } from '../restapi.service';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { NgForm } from '@angular/forms';

describe('TransactionFormComponent', () => {
  let component: TransactionFormComponent;
  let fixture: ComponentFixture<TransactionFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      providers: [ HttpClient, HttpHandler ],
      declarations: [ TransactionFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TransactionFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
