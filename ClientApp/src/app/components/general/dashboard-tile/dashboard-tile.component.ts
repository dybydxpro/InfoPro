import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard-tile',
  templateUrl: './dashboard-tile.component.html',
  styleUrl: './dashboard-tile.component.scss',
})
export class DashboardTileComponent implements OnInit {
  @Input() data: any = { route: '' };

  constructor(private router: Router) {}

  ngOnInit(): void {}

  redirect(route: string): void {
    this.router.navigate([route]);
  }
}
