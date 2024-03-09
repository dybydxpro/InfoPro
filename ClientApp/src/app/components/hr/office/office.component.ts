import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {Location} from '@angular/common';

@Component({
  selector: 'app-office',
  templateUrl: './office.component.html',
  styleUrl: './office.component.scss'
})
export class OfficeComponent implements OnInit{
  isLoading: boolean = false;
  isVisibleDepartment: boolean = false;
  isVisibleDesignation: boolean = false;

  constructor(private router: Router, private location: Location) {}

  ngOnInit(): void {
    
  }

  goBack(): void {
    this.location.back();
  }

  handleClose(): void {
    this.isVisibleDepartment = false;
    this.isVisibleDesignation = false;
  }

  submitDepartment(): void {

  }

  submitDesignation(): void {
    
  }
}
