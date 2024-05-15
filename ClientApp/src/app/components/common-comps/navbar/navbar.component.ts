import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit {
  user: any = {};

  constructor(
    private router: Router,
  ) {
    let token = localStorage.getItem('token');
    if(token === null){
      this.router.navigate(['/unauthorized']);
    }
  }

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('user') || "{}");
    this.getAvatarVal();
  }

  getAvatarVal(): string {
    let fn = this.user.firstName;
    let ln = this.user.lastName;

    if(fn !== null && ln !== null){
      let avater = fn.toUpperCase().substr(0, 1) + ln.toUpperCase().substr(0, 1);
      return avater;
    }
    else {
      return "";
    }
  }

  onLogout(): void {
    localStorage.clear();
    this.router.navigate(['/']);
  }

  navigateToHome(): void {
    this.router.navigate(['/home']);
  }
}
