import { Component, OnInit } from '@angular/core';
import { DepositService } from '../services/deposit.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AccountService } from '../services/account.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-deposit',
  templateUrl: './deposit.component.html',
  styleUrls: ['./deposit.component.css']
})
export class DepositComponent implements OnInit {
  public id: string;
  
  constructor(private route: ActivatedRoute, private deposit: DepositService, private account: AccountService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
  }

  form = new FormGroup(
    {
      amount: new FormControl(0, Validators.required)
    }
  )

  onSubmit() {
   this.deposit.depositMoney(this.id, this.form.get('amount').value)
   .subscribe(
    res => {
      console.log(res);
    },
    err => { console.log(err); 
    });
  }

}
  