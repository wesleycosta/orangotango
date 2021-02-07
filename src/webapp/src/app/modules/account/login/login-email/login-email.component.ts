import { EventEmitter, OnInit } from '@angular/core';
import { Component, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-login-email',
  templateUrl: './login-email.component.html',
  styleUrls: ['./login-email.component.scss'],
})
export class LoginEmailComponent implements OnInit {
  @Output()
  submitEvent = new EventEmitter<string>();
  loading = false;
  form!: FormGroup;

  constructor(
    private readonly userService: UserService,
    private readonly notificationService: NotificationService,
    private readonly formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.form = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
    });
  }

  submit(): void {
    if (this.loading) {
      return;
    }

    this.loading = true;
    this.sendRequestHandle();
  }

  sendRequestHandle(): void {
    if (!this.isValid()) {
      this.loading = false;
      return;
    }

    const email = this.form.controls.email.value;
    this.sendRequest(email);
  }

  isValid(): boolean {
    if (!this.form.valid) {
      this.notificationService.error('O e-mail é inválido');
      return false;
    }

    return true;
  }

  sendRequest(email: string): void {
    this.userService.hasEmail(email).subscribe(
      (response) => {
        this.loading = false;
        if (!response.data) {
          this.notificationService.error('Usuário não encontrado');
          return;
        }

        this.submitEvent.emit(email);
      },
      (error) => {
        this.loading = false;
        this.notificationService.notifyBadRequest(error);
      }
    );
  }
}
