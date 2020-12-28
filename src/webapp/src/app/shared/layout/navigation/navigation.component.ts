import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss'],
})
export class NavigationComponent {
  isExpanded = false;

  constructor(private notificationService: NotificationService) {
    notificationService.connect();
  }

  public changeExpanded(event: any) {
    this.isExpanded = event;
  }
}
