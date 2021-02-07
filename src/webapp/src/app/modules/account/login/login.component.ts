import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  public emailIsVisible = true;
  email!: string;

  public emailEvent(email: string) {
    this.email = email;
    this.emailIsVisible = false;
  }
}
