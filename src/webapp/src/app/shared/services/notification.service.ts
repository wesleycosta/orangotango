import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Injectable()
export class NotificationService {
  _hubConnection: HubConnection = new HubConnectionBuilder()
  .withUrl('https://localhost:5000/notification-hub')
  .build();

  dictStocks = {
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

  connect(): void {
    console.log('start');
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }

  connectToNotification(symbol: string) {
    this._hubConnection.invoke('ConnectToNotification', symbol);
  }

  private createConnection() {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:5000/notification-hub')
      .build();
  }

  private startConnection(): void {
    this._hubConnection
      .start()
      .then(() => {
        for (let key in this.dictStocks) {
          this.connectToNotification(key);
        }
      })
      .catch(() => {

      });
  }

  private registerOnServerEvents(): void {
    this._hubConnection.on('NotificationAll', (data: any) => {
      console.log(data);
    });
  }
}
