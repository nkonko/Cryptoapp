import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

const base_url = environment.base_url;

@Injectable({
  providedIn: 'root'
})
export class DepositService {
  
  private api = 'Account/Deposit/';
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  
  constructor(private http: HttpClient) { }

  public depositMoney(id:string, amount:number){
    return this.http.put(`${base_url}${this.api}/${id}`,amount,{ headers: this.headers});
  }

}
