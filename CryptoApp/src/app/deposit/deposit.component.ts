import { Component, OnInit } from '@angular/core';
import { DepositService } from '../services/deposit.service';

@Component({
  selector: 'app-deposit',
  templateUrl: './deposit.component.html',
  styleUrls: ['./deposit.component.css']
})
export class DepositComponent implements OnInit {

  constructor(private deposit: DepositService) { }

  ngOnInit(): void {
  }

  public depositMoney(amount: number)
  {
    this.deposit.depositMoney(amount);
  }

}
