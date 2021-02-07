import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { Router } from '@angular/router';
import { LocalStorageService } from './local-storage.service';

@Injectable()
export class ErrorInterceptorService implements HttpInterceptor {
  constructor(
    private readonly router: Router,
    private readonly localStorageService: LocalStorageService
  ) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      return next.handle(req).pipe(catchError(error => {
          if (error instanceof HttpErrorResponse) {
              if (error.status === 401) {
                this.unauthorized();
              }

              if (error.status === 403) {
                this.forbidden();
              }
          }

          return throwError(error);
      }));
  }

  private unauthorized(): void {
    this.localStorageService.clear();
    this.router.navigate(['/account/login'], { queryParams: { returnUrl: this.router.url }});
  }

  private forbidden(): void {
    // TODO
    this.router.navigate(['/forbidden']);
  }
}
