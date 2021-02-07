import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DrawerRailModule } from 'angular-material-rail-drawer';
import { LayoutModule } from './shared/layout/layout.module';
import { ComponentsModule } from './shared/components/components.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { NotificationService } from './shared/services/notification.service';
import { LocalStorageService } from './shared/services/local-storage.service';
import { ErrorInterceptorService } from './shared/services/error-interceptor.service';
import { AuthenticatedUserGuard } from './shared/guards/authenticated-user.guard';
import { LoginGuard } from './shared/guards/login.guard';

export const httpInterceptorProviders = [
  {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptorService,
    multi: true,
  },
];

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    DrawerRailModule,
    LayoutModule,
    ComponentsModule,
    HttpClientModule,
    MatSnackBarModule,
  ],
  providers: [
    LoginGuard,
    AuthenticatedUserGuard,
    NotificationService,
    LocalStorageService,
    httpInterceptorProviders,
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
