import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { DepartmentService } from '../../../service/hr/department.service';
import { DesignationService } from '../../../service/hr/designation.service';
import { NotificationService } from '../../../common/notification.service';

@Component({
  selector: 'app-office',
  templateUrl: './office.component.html',
  styleUrl: './office.component.scss'
})
export class OfficeComponent implements OnInit{
  isLoading: boolean = false;
  isVisibleDepartment: boolean = false;
  isVisibleDesignation: boolean = false;
  departmentForm: UntypedFormGroup;
  designationForm: UntypedFormGroup;
  departments: any[];
  department: any;
  designations: any[];
  designation: any;

  constructor(
    private router: Router, 
    private location: Location,
    private fb: UntypedFormBuilder,
    private departmentService: DepartmentService,
    private designationService: DesignationService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.departmentForm = this.fb.group({
      departmentName: [null, [Validators.required]]
    });

    this.designationForm = this.fb.group({
      designationName: [null, [Validators.required]]
    });

    this.getDepartments();
    this.getDesignations();
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

  goBack(): void {
    this.location.back();
  }

  handleClose(): void {
    this.isVisibleDepartment = false;
    this.isVisibleDesignation = false;

    this.departmentForm = this.fb.group({
      departmentName: [null, [Validators.required]]
    });

    this.designationForm = this.fb.group({
      designationName: [null, [Validators.required]]
    });
  }

  submitDepartment(): void {
    this.department = {
      'departmentName': this.departmentForm.get('departmentName')?.value
    }
    this.departmentService.postDepartment(this.department).subscribe(
      (res: any) => {
        console.log(res);
        this.notificationService.savingSuccess('Department Saved!');
        this.getDepartments();
      }, (err: any) => {
        console.error(err);
        this.notificationService.savingError('Department Not Saved!');
      }
    );
    this.handleClose();
  }

  submitDesignation(): void {
    this.designation = {
      'designationName': this.designationForm.get('designationName')?.value
    }
    this.designationService.postDesignation(this.designation).subscribe(
      (res: any) => {
        console.log(res);
        this.notificationService.savingSuccess('Designation Saved!');
        this.getDesignations();
      }, (err: any) => {
        console.error(err);
        this.notificationService.savingError('Designation Not Saved!');
      }
    );
    this.handleClose();
  }
}
