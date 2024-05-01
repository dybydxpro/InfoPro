import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { PlanStructureService } from '../../../service/planning/plan-structure.service';
import { NotificationService } from '../../../common/notification.service';
import { FileGenService } from '../../../service/planning/file-gen.service';

@Component({
  selector: 'app-generate-plan',
  templateUrl: './generate-plan.component.html',
  styleUrl: './generate-plan.component.scss',
})
export class GeneratePlanComponent implements OnInit {
  plannings: any[] = [];
  planStructs: number[] = [];
  fileLists: any[] = [];
  acceptedList: string[] = [];
  isLoading: boolean = false;

  constructor(
    private location: Location,
    private planStructureService: PlanStructureService,
    private notificationService: NotificationService,
    private fileGenService: FileGenService
  ) {}

  ngOnInit(): void {
    this.acceptedList = [
      'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
    ];

    this.getData();
  }

  goBack(): void {
    this.location.back();
  }

  getData(): void {
    this.planStructureService.getAllPlanStructures().subscribe(
      (res: any[]) => {
        this.plannings = res;
      },
      (err: any) => {
        this.notificationService.loadingError();
        console.error(err);
      }
    );
  }

  beforeUpload = (file: any) => {
    const fileList: File[] = [];
    this.fileLists = fileList.concat(file);
    return false;
  };

  handleUpload(event: any): void {
    // console.log(event);
  }

  uploadToGen(): void {
    const formData = new FormData();
    formData.append('File', this.fileLists[0]);

    this.planStructs.forEach((planId: number) => {
      formData.append('Templates', planId.toString());
    });

    this.fileGenService.handleSpredsheets(formData).subscribe(
      (res: any) => {
        console.log(res);
        this.downloadFile(res.file);
      },
      (err: any) => {
        this.notificationService.uploadingFileError('File upload failed!');
        console.error(err);
      }
    );
  }

  downloadFile(file: any): void {
    const byteCharacters = atob(file.fileContents);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], {
      type: `.xlsx`,
    });

    const url = URL.createObjectURL(blob);

    const a = document.createElement('a');
    document.body.appendChild(a);
    a.style.display = 'none';
    a.href = url;
    a.download = file.fileDownloadName;
    a.click();

    window.URL.revokeObjectURL(url);
  }
}
