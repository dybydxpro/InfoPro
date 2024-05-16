import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { IeService } from './../../../service/ie/ie.service';
import { StylesService } from './../../../service/ie/styles.service';
import { EmployeeService } from './../../../service/hr/employee.service';
import { UntypedFormGroup, UntypedFormBuilder, FormArray, Validators } from '@angular/forms';
import { NotificationService } from '../../../common/notification.service';

@Component({
  selector: 'app-styles',
  templateUrl: './styles.component.html',
  styleUrl: './styles.component.scss'
})
export class StylesComponent implements OnInit {
  styles: any[] = [];
  employees: any[] = [];
  isVisibleModal: boolean = false;
  styleForm: UntypedFormGroup;
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
    this.getStyles();

    this.styleForm = this.fb.group({
      code: [null, [Validators.required]],
      smv: [null, [Validators.min(0)]],
    });
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

  goBack(): void {
    this.location.back();
  }

  handleClose(): void {
    this.isVisibleModal = false;
  }

  submitStyle(): void {
    let data = {
      "code": this.styleForm.get('code')?.value,
      "smv": this.styleForm.get('smv')?.value
    };

    this.stylesService.postStyle(data).subscribe(
      (res: any) => {
        this.getStyles(); 
        this.isVisibleModal = false;
        this.notificationService.savingSuccess("Style Saving Successed!");
      }, (err: any) => {
        console.error(err);
        this.notificationService.savingError("Style Saving Failed!");
      }
    );
  }
}
