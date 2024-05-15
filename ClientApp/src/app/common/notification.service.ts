import { Injectable } from '@angular/core';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor(private notification: NzNotificationService) {}

  success(message: string) {
    this.notification.success('Success', message, {
      nzPlacement: 'bottomRight',
    });
  }

  error(message: string) {
    this.notification.error('Error', message, { nzPlacement: 'bottomRight' });
  }

  failure() {
    this.notification.error(
      'Failure',
      'Operation failed, please retry or contact support',
      { nzPlacement: 'bottomRight' }
    );
  }

  loadingError() {
    this.notification.error(
      'Error',
      'There was an error loading data please retry.',
      { nzPlacement: 'bottomRight' }
    );
  }

  entityLoadingError(entityName: string) {
    this.notification.error(
      'Error',
      `There was an error loading ${entityName} please retry.`,
      { nzPlacement: 'bottomRight' }
    );
  }

  savingSuccess(entityName: string) {
    this.notification.success(entityName, 'Successfully saved', {
      nzPlacement: 'bottomRight',
    });
  }

  savingError(entityName: string) {
    this.notification.error(
      entityName,
      'There was an error saving data please retry.',
      { nzPlacement: 'bottomRight' }
    );
  }

  updatingSuccess(entityName: string) {
    this.notification.success(entityName, 'Successfully updated', {
      nzPlacement: 'bottomRight',
    });
  }

  updatingError(entityName: string) {
    this.notification.error(
      entityName,
      'There was an error updating data please retry.',
      { nzPlacement: 'bottomRight' }
    );
  }

  updloadingFileSucess(entityName: string) {
    this.notification.success(entityName, 'Successfully uploaded', {
      nzPlacement: 'bottomRight',
    });
  }

  uploadingFileError(entityName: string) {
    this.notification.error(
      entityName,
      'There was an error uploading file please retry.',
      { nzPlacement: 'bottomRight' }
    );
  }

  fileExceededError(size: number) {
    this.notification.error(
      'Error',
      `Maximum allowed file size is ${size} Mb, please reduce the file size and try again.`,
      { nzPlacement: 'bottomRight' }
    );
  }

  deletingSuccess(entityName: string) {
    this.notification.success(entityName, 'Successfully deleted', {
      nzPlacement: 'bottomRight',
    });
  }

  deletingError(entityName: string) {
    this.notification.error(
      entityName,
      'There was an error deleting data please retry.',
      { nzPlacement: 'bottomRight' }
    );
  }
}
