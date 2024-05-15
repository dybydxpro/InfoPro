import { Component, OnInit } from '@angular/core';
import { PlanStructureService } from '../../service/planning/plan-structure.service';
import { NotificationService } from '../../common/notification.service';
import { Location } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalRef, NzModalService } from 'ng-zorro-antd/modal';

@Component({
  selector: 'app-planning',
  templateUrl: './planning.component.html',
  styleUrl: './planning.component.scss'
})
export class PlanningComponent implements OnInit {
  plannings: any[] = [];
  planning: any = {};
  isEdit: boolean = false;
  isVisibleModal: boolean = false;
  isLoading: boolean = false;
  planningForm: FormGroup;
  confirmModal?: NzModalRef;

  constructor(
    private planStructureService: PlanStructureService,
    private notificationService: NotificationService,
    private location: Location,
    private fb: FormBuilder,
    private modal: NzModalService
  ) {}

  ngOnInit(): void {
    this.getData();

    this.planningForm = this.fb.group({
      name: [null, [Validators.required]],
      days: [null, [Validators.required]]
    });
  }

  getData(): void {
    this.planStructureService.getAllPlanStructures().subscribe(
      (res: any[]) => {
        this.plannings = res;
      }, (err: any) => {
        this.notificationService.loadingError();
        console.error(err);
      }
    );
  }

  goBack(): void {
    this.location.back();
  }

  selectPlan(id: number): any {
    return this.plannings.filter(p => p.id === id);
  }

  submitPlanStruct(): void {
    this.isEdit === false ? this.createPlanStruct() : this.updatePlanStruct();
  }

  createPlanStruct(): void {
    let data: any = {
      "name": this.planningForm.get('name')?.value,
      "dayCount": this.planningForm.get('days')?.value
    }

    this.planStructureService.postPlanStructure(data).subscribe(
      (res: any) => {
        this.handleClose();
        this.getData();
        this.notificationService.savingSuccess("Plan Structure Save Successed!");
      }, (err: any) => {
        this.notificationService.savingError("Plan Structure Save Failed!");
        console.error(err);
      }
    );
  }

  updatePlanStruct(): void {
    this.planning[0].name = this.planningForm.get('name')?.value;
    this.planning[0].dayCount = this.planningForm.get('days')?.value;

    this.planStructureService.putPlanStructure(this.planning[0]).subscribe(
      (res: any) => {
        this.handleClose();
        this.getData();
        this.notificationService.updatingSuccess("Plan Structure Update Successed!");
      }, (err: any) => {
        this.notificationService.updatingError("Plan Structure Update Failed!");
        console.error(err);
      }
    );
  }

  handleClose(): void {
    this.isEdit = false;
    this.isVisibleModal = false;

    this.planningForm = this.fb.group({
      name: [null, [Validators.required]],
      days: [null, [Validators.required]]
    });
  }

  editPS(id: number): void {
    this.isEdit = true;
    this.planning = this.selectPlan(id);
    this.planningForm.get('name')?.setValue(this.planning[0].name);
    this.planningForm.get('days')?.setValue(this.planning[0].dayCount);
    this.isVisibleModal = true;
  }

  showConfirm(id: number): void {
    this.confirmModal = this.modal.confirm({
      nzTitle: 'Do you Want to delete these items?',
      nzContent: '',
      nzOnOk: () => this.deletePS(id)
    });
  }

  deletePS(id: number): void {
    this.planStructureService.deletePlanStructure(id).subscribe(
      (res: any) => {
        this.getData();
        this.notificationService.deletingSuccess("Plan Structure Delete Successed!");
      }, (err: any) => {
        console.error(err);
        this.notificationService.deletingError("Plan Structure Delete Failed!")
      }
    );
  }
}
