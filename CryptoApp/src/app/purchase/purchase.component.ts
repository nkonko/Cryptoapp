import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements OnInit {
  public isDolar = false;
  public isCrypto = false;

  constructor() { }

  ngOnInit(): void {
  }

  form = new FormGroup(
    {
      amountFrom: new FormControl(0, Validators.required),
      amountTo: new FormControl(0, Validators.required)
    }
  )

  onSubmit(){
    
  }
}
