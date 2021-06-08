import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  
  public id: number;
  public isCreated = false;
  constructor(private accountService:AccountService, private router:Router) { }

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
      (res: number) => {
        this.id  = res;
        
      },
      err => { console.log(err); 
      });
    this.isCreated = true;
    this.form.reset();
  }

  public onButtonClick(accNumber:number){
    this.router.navigate(["/deposit", accNumber])
  }
  
}
