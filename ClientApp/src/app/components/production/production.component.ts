import { Component, OnInit } from '@angular/core';
import { ProdService } from '../../service/prod/prod.service';

@Component({
  selector: 'app-production',
  templateUrl: './production.component.html',
  styleUrl: './production.component.scss'
})
export class ProductionComponent implements OnInit {
  isLoading: boolean = false;
  forecast: number = 0

  constructor(
    private prodService: ProdService
  ) {}

  ngOnInit(): void {
    
  }

  handleForecast(): void {
    this.isLoading = true;

    this.prodService.handleForecast().subscribe(
      (res: any) => {
        console.log(res);
        this.forecast = res;
        this.isLoading = false;
      }, (err: any) => {
        console.error(err);
        this.isLoading = false;
      }
    )
  }
}
