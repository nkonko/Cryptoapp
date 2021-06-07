import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  constructor() { }

  form = new FormGroup(
    {
      name: new FormControl(0, Validators.required),
      alias: new FormControl(0, Validators.required)
    }
  )

  ngOnInit(): void {
  }

}
