import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

const base_url = environment.base_url;

@Injectable({
  providedIn: 'root'
})
export class ExchangeService {
  private api = 'Exchange/ArsToUsd';
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  public exchangeArsToUsd(id:string, amount:number) : Observable<any>{
    let data = {
      "id": id,
      "amount":amount
    };
    let body = JSON.stringify(data);

    return this.http.post(`${base_url}${this.api}`,body,{ headers: this.headers});
  }
}
