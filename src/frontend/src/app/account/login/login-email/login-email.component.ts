import { EventEmitter } from '@angular/core';
import { Component, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-login-email',
  templateUrl: './login-email.component.html',
  styleUrls: ['./login-email.component.scss'],
})
export class LoginEmailComponent implements OnInit {
  @Output()
  public submitEvent = new EventEmitter<boolean>();

  constructor() {}

  ngOnInit(): void {}

  submit(): void {
    this.submitEvent.emit(true);
  }
}
