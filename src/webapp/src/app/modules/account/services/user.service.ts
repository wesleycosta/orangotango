import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/shared/services/base.service';
import { catchError, map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UserService extends BaseService {
  private endpoint: string = this.getUrlEndpoint('users');

  constructor(private http: HttpClient) {
    super();
  }

  hasEmail(email: string): Observable<boolean> {
    return this.http
      .get(`${this.endpoint}/has-email?email=${email}`, this.getHeaderJson())
      .pipe(map(this.extractData), catchError(this.serviceError));
  }
}
