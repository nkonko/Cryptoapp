import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html'
})
export class NavbarComponent implements OnInit {

  constructor(public auth:AuthService, private router: Router ) { }

  ngOnInit(): void {
  }

  public loginWithRedirect(): void{
    this.auth.loginWithRedirect();
  }

  public logout(){
    this.auth.logout();
  }

  public depositNav(accNumber:number){
    this.router.navigate(["/deposit", accNumber])
  }
}
