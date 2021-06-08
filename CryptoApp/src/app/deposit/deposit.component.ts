import { Component, OnInit } from '@angular/core';
import { DepositService } from '../services/deposit.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-deposit',
  templateUrl: './deposit.component.html',
  styleUrls: ['./deposit.component.css']
})
export class DepositComponent implements OnInit {
  public id: string;
  public isDeposited: boolean;

  constructor(private router: Router, private route: ActivatedRoute, private deposit: DepositService) { }

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
    (res:boolean) => {
      console.log(res);
      this.isDeposited = res;
    },
    err => { console.log(err); 
    });
  }

  public onButtonClick(accNumber:string){
    this.router.navigate(["/purchase", accNumber])
  }

}
  