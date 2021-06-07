import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { account } from '../model/account.model';

const base_url = environment.base_url;

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private api = 'Account/';
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  
  constructor(private http: HttpClient) { }

  public createAccount(formData: account) {
    return this.http.post(`${base_url}${this.api}`,formData,{headers: this.headers});
  }

  public getAccount(id:number){
    return this.http.get(`${base_url}${this.api}/${id}`,{headers: this.headers})
  }
}
