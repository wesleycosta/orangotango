import { EventEmitter, Output } from '@angular/core';
import { Component } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  private isExpanded = false;

  @Output()
  public expandedEvent = new EventEmitter<boolean>();

  changeExpanded(): void {
    this.isExpanded = !this.isExpanded;
    this.expandedEvent.emit(this.isExpanded);
  }
}
