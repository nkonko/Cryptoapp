import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private url = 'https://localhost:44361/Account/';
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  
  constructor(private http: HttpClient) { }


  public createAccount() {
    this.http.post(this.url,,{headers: this.headers}).subscribe(
      () => {
      },
      err => { console.log(err); }
    );
  }
}
