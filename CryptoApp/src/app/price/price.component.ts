import { Component, OnInit } from '@angular/core';
import { PriceService } from '../services/price.service';

@Component({
  selector: 'app-price',
  templateUrl: './price.component.html',
  styleUrls: ['./price.component.css']
})
export class PriceComponent implements OnInit {
  
  public usdPurchase = '$165'
  public usdSale = '$160'
  public btcPurchase = '$45000'
  public btcSale = '$40000'


  constructor(private priceService: PriceService) { }

  ngOnInit(): void {
    this.priceService.getMoneyPrice();
  }


}
