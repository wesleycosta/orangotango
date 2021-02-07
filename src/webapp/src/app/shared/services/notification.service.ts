import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class NotificationService {
  constructor(private readonly snackBar: MatSnackBar) {}

  success(message: string): void {
    this.openSnackBar(message, 'success-snackbar');
  }

  error(message: string): void {
    console.log(message);
    this.openSnackBar(message, 'error-snackbar');
  }

  openSnackBar(message: string, type: string): void {
    this.snackBar.open(message, 'OK', {
      duration: 3000,
      panelClass: [type],
    });
  }

  notifyBadRequest(data: any): void {
    if (!data.error) {
      return;
    }

    if (!data.error.errors) {
      return;
    }

    const errors: any[] = data.error.errors;
    errors.forEach((message) => {
      this.error(message);
    });
  }
}
