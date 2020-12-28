import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { NavigationComponent } from './navigation/navigation.component';
import { MaterialModule } from './material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NotificationComponent } from './notification/notification.component';

@NgModule({
  declarations: [NavbarComponent, NavigationComponent, NotificationComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    RouterModule,
  ],
  exports: [NavbarComponent, NavigationComponent, NotificationComponent],
})
export class LayoutModule {}
