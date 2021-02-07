import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { environment } from 'src/environments/environment';

@Injectable()
export class NotificationWebSocketService {
  private _hubConnection: HubConnection = new HubConnectionBuilder()
    .withUrl(`${environment.apiWebsocket}notification-hub`)
    .build();

  private dictStocks = {
    ITSA4: {
      startValue: 20.0,
      currentValue: 20.0,
      change: 0.0,
    },
    TAEE11: {
      startValue: 20.0,
      currentValue: 20.0,
      change: 0.0,
    },
    PETR4: {
      startValue: 20.0,
      currentValue: 20.0,
      change: 0.0,
    },
  };

  public notifications: any[] = [];

  connect(): void {
    this.registerOnServerEvents();
    this.startConnection();
  }

  connectToNotification(symbol: string) {
    this._hubConnection.invoke('ConnectToNotification', symbol);
  }

  private startConnection(): void {
    this._hubConnection
      .start()
      .then(() => {
        for (let key in this.dictStocks) {
          this.connectToNotification(key);
        }
      })
      .catch(() => {});
  }

  private registerOnServerEvents(): void {
    this._hubConnection.on('NotificationAll', (data: any) => {
      console.log(data);
      this.notifications.push(data);
    });
  }
}
