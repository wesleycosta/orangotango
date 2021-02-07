import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ResponseBase } from 'src/app/shared/models/response-base';
import { UserAuthenticated } from 'src/app/shared/models/user-authenticated';
import { RequestBaseService } from 'src/app/shared/services/request-base.service';
import { SignInUser } from '../models/sign-in-user';

@Injectable()
export class AuthService extends RequestBaseService {
  private endpoint: string = this.getUrlEndpoint('auth');

  constructor(private http: HttpClient) {
    super();
  }

  signIn(signInUser: SignInUser): Observable<ResponseBase<UserAuthenticated>> {
    return this.http
      .post(this.endpoint, JSON.stringify(signInUser), this.getHeaderJson())
      .pipe(map(this.extractData), catchError(this.serviceError));
  }
}
