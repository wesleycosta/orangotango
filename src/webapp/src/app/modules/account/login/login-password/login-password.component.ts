import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LocalStorageService } from 'src/app/shared/services/local-storage.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { SignInUser } from '../../models/sign-in-user';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login-password',
  templateUrl: './login-password.component.html',
  styleUrls: ['./login-password.component.scss'],
})
export class LoginPasswordComponent implements OnInit {
  @Input()
  email!: string;

  showPassword: boolean = false;
  form!: FormGroup;
  loading: boolean = false;

  constructor(
    private readonly router: Router,
    private readonly formBuilder: FormBuilder,
    private readonly notificationService: NotificationService,
    private readonly authService: AuthService,
    private readonly localStorageService: LocalStorageService
  ) {}

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.form = this.formBuilder.group({
      password: ['', [Validators.required, Validators.minLength(4)]],
    });
  }

  get type(): string {
    return this.showPassword ? 'text' : 'password';
  }

  showPasswordClicked(): void {
    this.showPassword = !this.showPassword;
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

    const password = this.form.controls.password.value;
    this.sendRequest(password);
  }

  isValid(): boolean {
    if (!this.form.valid) {
      this.notificationService.error('A senha é inválida');
      return false;
    }

    return true;
  }

  getModel(password: string): SignInUser {
    return {
      emailAdrress: this.email,
      password: password,
    };
  }

  sendRequest(password: string): void {
    const userModel = this.getModel(password);
    this.authService.signIn(userModel).subscribe(
      (response) => {
        this.loading = false;
        if (!response.success) {
          this.notificationService.error('A senha é inválida');
          return;
        }

        this.localStorageService.save(response.data);
        this.router.navigate(['dashboard']);
      },
      (error) => {
        this.loading = false;
        this.notificationService.notifyBadRequest(error);
      }
    );
  }
}
