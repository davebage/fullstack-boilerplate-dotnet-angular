import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'

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

  postTransaction(transactionrequest: any) {
    let url = "http://localhost:3000/transaction";
    return this.http.post(url, transactionrequest, this.httpOptions);
  }
}
