import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { IeService } from './../../service/ie/ie.service';
import { StylesService } from './../../service/ie/styles.service';
import { EmployeeService } from '../../service/hr/employee.service';
import { UntypedFormGroup, UntypedFormBuilder, FormArray, Validators } from '@angular/forms';
import { NotificationService } from '../../common/notification.service';

@Component({
  selector: 'app-ie',
  templateUrl: './ie.component.html',
  styleUrl: './ie.component.scss'
})
export class IeComponent implements OnInit {
  productionFloor: any[] = [];
  styles: any[] = [];
  employees: any[] = [];
  selectedEmployees: number[] = [];
  isVisibleModal: boolean = false;
  ieForm: UntypedFormGroup;
  isLoading: boolean = false;

  constructor(
    private location: Location, 
    private ieService: IeService,
    private stylesService: StylesService,
    private employeeService: EmployeeService,
    private fb: UntypedFormBuilder,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.getProductionFloors();
    this.getStyles();
    this.getEmployees();

    this.ieForm = this.fb.group({
      name: [null, [Validators.required]],
      workingHours: [null, [Validators.min(0)]],
      styleId: [null, [Validators.required]],
      workers: this.fb.array([
        this.fb.group({
          value: [null, [Validators.required]],
        })
      ]),
    });

    // this.notificationService.savingSuccess("Production Floor Saving Successed!");
  }

  goBack(): void {
    this.location.back();
  }

  getProductionFloors(): void {
    this.ieService.getAllProductionFloors().subscribe(
      (res: any) => {
        this.productionFloor = res;
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
      }, (err: any) => {
        console.error(err);
      }
    )
  }

  getEmployees(): void {
    this.employeeService.getAllEmployees().subscribe(
      (res: any) => {
        this.employees = res;
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

  workers() : FormArray {
    return this.ieForm.get("workers") as FormArray
  }

  handleClose(): void {
    this.isVisibleModal = false;
  }

  submitEmployee(): void {
    let workers: any[] = [];
    this.selectedEmployees.forEach((emp: number) => {
      workers.push({
        "employeeId": emp,
        "productionFloorId": 0
      });
    });

    let data: any = {
      "name": this.ieForm.get('name')?.value,
      "workingHours": this.ieForm.get('workingHours')?.value,
      "styleId": this.ieForm.get('styleId')?.value,
      "flowWorkers": workers
    }

    console.log(data)
    this.ieService.postProductionFloor(data).subscribe(
      (res: any) => {
        this.getProductionFloors();
        this.isVisibleModal = false;
      }, (err: any) => {
        console.error(err);
      }
    );
  }
}
