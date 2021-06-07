import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DepositService {
  
  private url = 'https://localhost:44361/Account/Deposit/1';
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  
  constructor(private http: HttpClient) { }

  public depositMoney(amount:number){
    this.http.put(this.url,amount,{ headers: this.headers}).subscribe(
      () => {
      },
      err => { console.log(err); }
    );
  }

}
