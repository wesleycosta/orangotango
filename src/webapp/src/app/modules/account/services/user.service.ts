import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { RequestBaseService } from 'src/app/shared/services/request-base.service';
import { ResponseBase } from 'src/app/shared/models/response-base';

@Injectable()
export class UserService extends RequestBaseService {
  private endpoint: string = this.getUrlEndpoint('users');

  constructor(private http: HttpClient) {
    super();
  }

  hasEmail(email: string): Observable<ResponseBase<boolean>> {
    return this.http
      .get(`${this.endpoint}/has-email?email=${email}`, this.getHeaderJson())
      .pipe(map(this.extractData), catchError(this.serviceError));
  }
}
