import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { forkJoin, Observable } from 'rxjs';
import { bankAccount } from '../model/bankaccount.model';
import { AccountService } from '../services/account.service';
import { ExchangeService } from '../services/exchange.service';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements OnInit {
  public id: string;
  public isDolar = false;
  public isCrypto = false;
  public balanceArs: number
  public account: bankAccount;
  public balanceUsd = 0;
  public dolarPrice = 165;
  public isDone = false;

  constructor(private accountSvc:AccountService, private exchScv: ExchangeService, private route: ActivatedRoute) {
    this.id = this.route.snapshot.paramMap.get('id');
    
    this.GetAccount().subscribe(results =>{
      this.account = results;
    
          if (results) {
            this.balanceArs = this.account.balance;
          }
    });
  }
  
  ngOnInit(): void {
  }
  
  form = new FormGroup(
    {
      quantity: new FormControl(0, Validators.required)
    });
    
    public checkBalance(){
      this.balanceUsd = this.quantity / this.dolarPrice;
    }
    
    public onPurchase(){
      forkJoin([this.Exchange(), this.GetAccount()]).subscribe(results => {
        if (results[0]) {
          this.isDone = true;
        }
          this.account = results[1];
    
          if (results[1]) {
            this.balanceArs = this.account.balance;
          }
      });
    }
    
    get quantity(){
      return this.form.controls['quantity'].value;
    }

    private GetAccount() : Observable<bankAccount> {
      return this.accountSvc.getAccount(this.id);
    }

    private Exchange(): Observable<boolean> {
      return this.exchScv.exchangeArsToUsd(this.id, this.quantity);
    }
}
