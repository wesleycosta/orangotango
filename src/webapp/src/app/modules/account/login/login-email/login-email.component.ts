import { EventEmitter } from '@angular/core';
import { Component, OnInit, Output } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-login-email',
  templateUrl: './login-email.component.html',
  styleUrls: ['./login-email.component.scss'],
})
export class LoginEmailComponent {
  @Output()
  public submitEvent = new EventEmitter<boolean>();
  loading = false;

  constructor(
    private readonly userService: UserService,
    private readonly notificationService: NotificationService
  ) {}

  submit(): void {
    this.loading = true;
    this.sendRequest();
  }

  sendRequest(): void {
    this.userService.hasEmail('wesley_costa@outlook.com').subscribe(
      (success) => {
        this.loading = false;
        if (!success) {
          this.notificationService.error('E-mail não encontrado');
          return;
        }

        this.submitEvent.emit(success);
      },
      (error) => {
        this.loading = false;
        this.notificationService.notifyBadRequest(error);
      }
    );
  }
}
