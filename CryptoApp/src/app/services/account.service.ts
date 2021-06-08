import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { account } from '../model/account.model';
import { map } from "rxjs/operators";
import { bankAccount } from '../model/bankaccount.model';

const base_url = environment.base_url;

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private api = 'Account';
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  
  constructor(private http: HttpClient) { }

  public createAccount(formData: account) {
    return this.http.post(`${base_url}${this.api}`,formData,{headers: this.headers});
  }

  public getAccount(id:number){
    return this.http.get(`${base_url}${this.api}/${id}`,{headers: this.headers}).pipe(map(resp => this.mapToAccount(resp)))
  }

  private mapToAccount(resp: Object){
    const accounts: bankAccount[] = [];
    
    if(resp === null){
      return;
    }

    Object.entries(resp).forEach(([k,v]) =>
      {
        let account = new bankAccount();
        account = v
        account.AccountNumb = k

        accounts.push(account);
      });
    return account;
  }
}
