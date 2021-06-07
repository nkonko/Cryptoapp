import { Component, OnInit } from '@angular/core';
import { DepositService } from '../services/deposit.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-deposit',
  templateUrl: './deposit.component.html',
  styleUrls: ['./deposit.component.css']
})
export class DepositComponent implements OnInit {

  constructor(private deposit: DepositService) { }

  ngOnInit(): void {
  }

  form = new FormGroup(
    {
      amount: new FormControl(0, Validators.required)
    }
  )

  onSubmit() {
   this.deposit.depositMoney(this.form.get('amount').value);
  }

}
  