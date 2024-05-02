import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { IeService } from './../../service/ie/ie.service';
import { StylesService } from './../../service/ie/styles.service';
import { EmployeeService } from '../../service/hr/employee.service';
import { FormGroup, FormBuilder, FormArray, Validators } from '@angular/forms';

@Component({
  selector: 'app-ie',
  templateUrl: './ie.component.html',
  styleUrl: './ie.component.scss'
})
export class IeComponent implements OnInit {
  productionFloor: any[] = [];
  styles: any[] = [];
  employees: any[] = [];
  isVisibleModal: boolean = false;
  ieForm: FormGroup;
  isLoading: boolean = false;

  constructor(
    private location: Location, 
    private ieService: IeService,
    private stylesService: StylesService,
    private employeeService: EmployeeService,
    private fb: FormBuilder,
  ) {}

  ngOnInit(): void {
    this.getProductionFloors();
    this.getStyles();

    this.ieForm = this.fb.group({
      name: [null, [Validators.required]],
      workingHours: [null, [Validators.min(0)]],
      styleId: [null, [Validators.required]],
      workers: this.fb.array([]),
    });
  }

  goBack(): void {
    this.location.back();
  }

  getProductionFloors(): void {
    this.ieService.getAllProductionFloors().subscribe(
      (res: any) => {
        this.productionFloor = res;
        console.log(res);
      },
      (err: any) => {
        console.error(err);
      }
    )
  }

  getStyles(): void {
    this.stylesService.getAllStyles().subscribe(
      (res: any) => {
        this.styles = res;
        console.log(res);
      }, (err: any) => {
        console.error(err);
      }
    )
  }

  getEmployees(): void {
    this.employeeService.getAllEmployees().subscribe(
      (res: any) => {
        this.employees = res;
        console.log(res);
      }, (err: any) => {
        console.error(err);
      }
    )
  }

  addItem(): void {
    let items = this.ieForm.get('workers') as FormArray;
    items.push(this.fb.group({
      value: '',
    }));
  }

  handleClose(): void {
    this.isVisibleModal = false;
  }

  submitEmployee(): void {

  }
}
