import { EventEmitter, Output } from '@angular/core';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageService } from '../../services/local-storage.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent {
  private isExpanded = false;

  @Output()
  public expandedEvent = new EventEmitter<boolean>();

  constructor(
    private readonly localStorageService: LocalStorageService,
    private readonly router: Router
  ) {}

  changeExpanded(): void {
    this.isExpanded = !this.isExpanded;
    this.expandedEvent.emit(this.isExpanded);
  }

  get name(): string {
    return this.localStorageService.getName();
  }

  logoff(): void {
    this.localStorageService.clear();
    this.router.navigate(['/account/login']);
  }
}
