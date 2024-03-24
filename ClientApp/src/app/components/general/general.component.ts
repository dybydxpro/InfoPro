import { Component, OnInit } from '@angular/core';
import { UserService } from './../../service/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-general',
  templateUrl: './general.component.html',
  styleUrl: './general.component.scss'
})
export class GeneralComponent implements OnInit {
  apps: any[] = [];
  constructor(
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.apps = [
      {
        title: 'Human Resources Management',
        img: './../../../../assets/hr.png',
        route: `/hr`
      },
      {
        title: 'Production Management',
        img: './../../../../assets/prod.png',
        route: `/production`
      },
      {
        title: 'Planning Management',
        img: './../../../../assets/plan.png',
        route: `/planning`
      },
      {
        title: 'Finished Good Management',
        img: './../../../../assets/fg.png',
        route: `/fg`
      },
      {
        title: 'Row Material Management',
        img: './../../../../assets/row.png',
        route: `/store`
      },
      {
        title: 'Industrial Engineering & Management',
        img: './../../../../assets/eng.png',
        route: `/ie`
      }
    ];
  }
}
