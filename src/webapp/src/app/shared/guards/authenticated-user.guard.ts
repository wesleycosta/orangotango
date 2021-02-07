import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { LocalStorageService } from '../services/local-storage.service';

@Injectable()
export class AuthenticatedUserGuard implements CanActivate {
  constructor(
    private readonly router: Router,
    private readonly localStorageService: LocalStorageService
  ) {}

  canActivate() {
    const isAuthenticated = this.localStorageService.hasData();

    if (!isAuthenticated) {
      this.router.navigate(['/account/login/'], {
        queryParams: { returnUrl: this.router.url },
      });
    }

    return isAuthenticated;
  }
}
