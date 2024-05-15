import { Component, OnInit, Input, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-graph-seg',
  templateUrl: './graph-seg.component.html',
  styleUrl: './graph-seg.component.scss'
})
export class GraphSegComponent implements OnInit, AfterViewInit  {
  @Input() graphData: any = {};
  @ViewChild('myChartCanvas') myChartCanvas!: ElementRef;
  chart: any;

  constructor() {}

  ngOnInit(): void { }

  ngAfterViewInit(): void {
    if(this.graphData.type === 'bar'){
      this.createBarChart();
    }
    else if (this.graphData.type === 'line'){
      this.createLineChart();
    }
  }

  createBarChart() {
    const ctx = document.getElementById('barChartCanvas') as HTMLCanvasElement;

    this.chart = new Chart(ctx, {
      type: this.graphData.type,
      data: {
        labels: this.graphData.labels,
        datasets: [{
          label: this.graphData.bigLable,
          data: this.graphData.data,
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)',
            'rgba(255, 159, 64, 0.2)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });
  }

  createLineChart() {
    const ctx = document.getElementById('lineChartCanvas') as HTMLCanvasElement;

    this.chart = new Chart(ctx, {
      type: this.graphData.type,
      data: {
        labels: this.graphData.labels,
        datasets: [{
          label: this.graphData.bigLable,
          data: this.graphData.data,
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)',
            'rgba(255, 159, 64, 0.2)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });
  }
}
