import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../../service/hr/employee.service';
import { DepartmentService } from '../../service/hr/department.service';
import { DesignationService } from '../../service/hr/designation.service';
import { NotificationService } from '../../common/notification.service';
import Employee from '../../models/Employee';
import Company from '../../models/Company';
import Department from '../../models/Department';
import Designation from '../../models/Designation';

@Component({
  selector: 'app-hr',
  templateUrl: './hr.component.html',
  styleUrl: './hr.component.scss'
})
export class HrComponent implements OnInit {
  isVisibleEmployee: boolean = false;
  employees: any[] = [];
  employeesBackup: any[] = [];
  searchValue: string = "";
  visibleNameSearch: boolean = false;
  isVisibleModal: boolean = false;
  isLoading: boolean = false;
  employeesForm: FormGroup;
  designations: Designation[] = [];
  departments: Department[] = [];

  constructor(
    private router: Router, 
    private location: Location, 
    private employeeService: EmployeeService,
    private departmentService: DepartmentService,
    private designationService: DesignationService,
    private fb: FormBuilder,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.getEmployees();
    this.getDepartments();
    this.getDesignations();

    this.employeesForm = this.fb.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      gender: [null, [Validators.required]],
      dob: [null, [Validators.required]],
      address: [null, [Validators.required]],
      nic: [null, [Validators.required, Validators.minLength(10), Validators.maxLength(12)]],
      designationId: [null, [Validators.required]],
      departmentId: [null, [Validators.required]]
    });
  }

  goBack(): void {
    this.location.back();
  }

  getEmployees(): void {
    this.employeeService.getAllEmployees().subscribe(
      (res: any) => {
        this.employees = res;
        this.employeesBackup = res;
      }, (err: any) => {
        console.error(err);
      }
    );
  }

  getDepartments(): void {
    this.departmentService.getAllDepartments().subscribe(
      (res: any) => {
        this.departments = res;
      }, (err: any) => {
        console.error(err);
      }
    );
  }

  getDesignations(): void {
    this.designationService.getAllDesignations().subscribe(
      (res: any) => {
        this.designations = res;
      }, (err: any) => {
        console.error(err);
      }
    );
  }

  reset(): void {
    this.searchValue = '';
    this.searchName();
  }

  searchName(): void {
    this.visibleNameSearch = false;
    this.employees = this.employeesBackup.filter((emp: any) => ((emp.firstName + " " + emp.lastName)).toLowerCase().indexOf(this.searchValue) !== -1);
  }

  handleClose(): void {
    this.isVisibleModal = false;
    this.employeesForm = this.fb.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      gender: [null, [Validators.required]],
      dob: [null, [Validators.required]],
      address: [null, [Validators.required]],
      nic: [null, [Validators.required, Validators.minLength(10), Validators.maxLength(12)]],
      designationId: [null, [Validators.required]],
      departmentId: [null, [Validators.required]]
    });
  }

  submitEmployee(): void {
    let data = {
      'firstName': this.employeesForm.get('firstName')?.value,
      'lastName': this.employeesForm.get('lastName')?.value,
      'gender': this.employeesForm.get('gender')?.value,
      'dob': new Date(this.employeesForm.get('dob')?.value).toISOString().split('T')[0],
      'address': this.employeesForm.get('address')?.value,
      'nic': this.employeesForm.get('nic')?.value,
      'designationId': this.employeesForm.get('designationId')?.value,
      'departmentId' : this.employeesForm.get('departmentId')?.value,
    };

    if(this.employeesForm.valid){
      this.employeeService.postEmployee(data).subscribe(
        (res: any) => {
          this.getEmployees();
          this.notificationService.savingSuccess('Employee submited');
        }, (err: any) => {
          console.error(err);
          this.notificationService.savingError('Employee submition failed!');
        }
      );
    } else {
      this.notificationService.error('Validation failed!');
    }
  }
}
