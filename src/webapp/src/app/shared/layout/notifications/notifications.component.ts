import { Component, OnInit } from '@angular/core';
import { NotificationWebSocketService } from '../../services/notification-web-socket.service';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.scss'],
})
export class NotificationsComponent implements OnInit {
  constructor(
    public readonly notificationService: NotificationWebSocketService
  ) {}

  ngOnInit(): void {
    this.notificationService.connect();
  }

  public get getNotifications(): any[] {
    return this.notificationService.notifications;
  }

  public get existsNotification(): boolean {
    return this.countNotifications > 0;
  }

  public get countNotifications(): number {
    const notifications = this.getNotifications;
    if (!notifications) {
      return 0;
    }

    return notifications.length;
  }
}
