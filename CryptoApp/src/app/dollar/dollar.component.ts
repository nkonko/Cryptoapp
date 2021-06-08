import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dollar',
  templateUrl: './dollar.component.html',
  styleUrls: ['./dollar.component.css']
})
export class DollarComponent implements OnInit {
 public balanceArs = 0;
 public balanceUsd = 0;
 public dolarPrice = 0;
  
 constructor() { }

  ngOnInit(): void {
  }

}
