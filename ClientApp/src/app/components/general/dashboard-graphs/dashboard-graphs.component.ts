import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard-graphs',
  templateUrl: './dashboard-graphs.component.html',
  styleUrl: './dashboard-graphs.component.scss'
})
export class DashboardGraphsComponent implements OnInit {
  graphData: any[] = [];

  constructor() {
    this.graphData = [
      {
        title: "Production Growth",
        value: 157953.00,
        type: "bar",
        labels: ['Red', 'Blue', 'Yellow'],
        bigLable: '# of Votes',
        data: [12, 19, 3, 5, 2, 3]
      },
      {
        title: "Grown Product",
        value: 157953.00,
        type: "bar",
        labels: ['Red', 'Blue', 'Yellow'],
        bigLable: '# of Votes',
        data: [12, 19, 3, 5, 2, 3]
      },
      {
        title: "Best Sold Products",
        value: 157953.00,
        type: "bar",
        labels: ['Red', 'Blue', 'Yellow'],
        bigLable: '# of Votes',
        data: [12, 19, 3, 5, 2, 3]
      },
      {
        title: "Income growth",
        value: 157953.00,
        type: "bar",
        labels: ['Red', 'Blue', 'Yellow'],
        bigLable: '# of Votes',
        data: [12, 19, 3, 5, 2, 3]
      }
    ];
  }

  ngOnInit(): void {
    
  }
}
