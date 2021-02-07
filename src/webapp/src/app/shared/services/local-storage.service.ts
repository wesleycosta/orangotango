import { Injectable } from '@angular/core';
import { UserAuthenticated } from '../models/user-authenticated';

@Injectable()
export class LocalStorageService {
  private key: string = 'orangotango.user';

  public getName(): string {
    return this.getUser()?.name ?? '';
  }

  public getEmail(): string {
    return this.getUser()?.email ?? '';
  }

  public getUser(): UserAuthenticated | null {
    if (!this.hasData()) {
      return null;
    }

    const user: UserAuthenticated = JSON.parse(this.getData());
    return user;
  }

  private getData(): string {
    const data = localStorage.getItem(this.key);
    return data ?? '';
  }

  public getToken(): string | null {
    const user = this.getUser();
    return user?.token ?? null;
  }

  public hasData(): boolean {
    return !!localStorage.getItem(this.key);
  }

  public save(userAuthenticated: UserAuthenticated): void {
    localStorage.setItem(this.key, JSON.stringify(userAuthenticated));
  }

  public clear(): void {
    localStorage.clear();
  }
}
