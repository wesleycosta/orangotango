import { HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LocalStorageService } from './local-storage.service';

export abstract class RequestBaseService {
  protected api: string = environment.api;
  protected localStorageService: LocalStorageService = new LocalStorageService();

  protected getHeaderJson() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    };
  }

  protected getUrlEndpoint(endpoint: string): string {
    return `${this.api}${endpoint}`;
  }

  protected getAuthorizationBearer() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: `Bearer ${this.localStorageService.getToken()}`,
      }),
    };
  }

  protected extractData(response: any) {
    return response;
  }

  protected serviceError(response: Response | any) {
    let customResponse = { error: { errors: [] } };

    if (response instanceof HttpErrorResponse) {
      if (response.statusText === 'Unknown Error') {
        response.error.errors = ['Ocorreu um erro desconhecido'];
        console.error(response);
        return throwError(response);
      }
    }

    if (response.status === 500) {
      return throwError(customResponse);
    }

    console.error(response);
    return throwError(response);
  }
}
