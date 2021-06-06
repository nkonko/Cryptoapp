import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';

import { AuthGuard } from '@auth0/auth0-angular';
import { DepositComponent } from './deposit/deposit.component';
import { PurchaseComponent } from './purchase/purchase.component';
import { SaleComponent } from './sale/sale.component';
import { WithdrawComponent } from './withdraw/withdraw.component';


const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'deposit', component: DepositComponent, canActivate: [AuthGuard]},
  {path: 'purchase', component: PurchaseComponent, canActivate: [AuthGuard]},
  {path: 'sale', component: SaleComponent, canActivate: [AuthGuard]},
  {path: 'withdraw', component: WithdrawComponent, canActivate: [AuthGuard]},
  {path: '**', pathMatch: 'full', redirectTo: ''},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
