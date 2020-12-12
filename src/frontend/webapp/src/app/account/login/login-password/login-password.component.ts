import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-password',
  templateUrl: './login-password.component.html',
  styleUrls: ['./login-password.component.scss'],
})
export class LoginPasswordComponent implements OnInit {
  public showPassword: boolean = false;

  constructor(private router: Router) {}

  ngOnInit(): void {}

  get type(): string {
    return this.showPassword ? 'text' : 'password';
  }

  showPasswordClicked() {
    this.showPassword = !this.showPassword;
  }

  submit(): void {
    this.router.navigate(['dashboard']);
  }
}
