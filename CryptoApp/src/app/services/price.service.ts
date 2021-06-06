import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { currency } from '../model/currency.model';

@Injectable({
  providedIn: 'root'
})
export class PriceService {
  private url = 'https://localhost:5000/api/GetUSDPrice';

  constructor(private http: HttpClient) { 
  }

  public getMoneyPrice(): void{

    this.http.get(this.url)
    .subscribe((resp: any) =>{
    });
    
  }
}
