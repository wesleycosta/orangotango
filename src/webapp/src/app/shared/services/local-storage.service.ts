import { UserAuthentication } from '../models/user';

export class LocalStorageService {
  public getUser(): UserAuthentication | null {
    if (!this.hasData()) {
      return null;
    }

    const user: UserAuthentication = JSON.parse(this.getData());
    return user;
  }

  private getData(): string {
    const data = localStorage.getItem('orangotango.user');
    return data ? '';
  }

  public getToken(): string | null {
    const user = this.getUser();
    return user?.token ?? null;
  }

  public hasData(): boolean {
    return !!localStorage.getItem('orangotango.user');
  }
}
