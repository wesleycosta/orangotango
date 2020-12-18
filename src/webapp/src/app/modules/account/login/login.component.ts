import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public isViewEmail = true;

  constructor() { }

  ngOnInit(): void {
  }

  public submitEmailEvent(event: boolean) {
    this.isViewEmail = !event;
  }
}
