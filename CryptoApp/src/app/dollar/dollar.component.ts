import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-dollar',
  templateUrl: './dollar.component.html',
  styleUrls: ['./dollar.component.css']
})
export class DollarComponent implements OnInit {
 @Input() balanceArs;
 public dolarPrice = 165;
  
 constructor() {
}

  ngOnInit(): void {
  }

 

 

}
