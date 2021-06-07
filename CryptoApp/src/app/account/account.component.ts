import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  constructor(private accountService:AccountService) { }

  form = new FormGroup(
    {
      name: new FormControl('', [Validators.required, Validators.minLength(3)]),
      alias: new FormControl('', [Validators.required, Validators.minLength(3)]),
      dni: new FormControl('', [Validators.required, Validators.minLength(8)])
    }
  )

  ngOnInit(): void {
  }

  public validField(control: string) : boolean{
    return this.form.controls[control].errors && 
           this.form.controls[control].touched
  }

  public save(){
    if(this.form.invalid){
      this.form.markAllAsTouched();
      return;
    }

    this.accountService.createAccount(this.form.value)
    .subscribe(
      res => {
        console.log(res);
      },
      err => { console.log(err); 
      });

    this.form.reset();
  }
  
}
