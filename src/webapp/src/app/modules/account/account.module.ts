import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { AccountRoutingModule } from './account-routing.module';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginEmailComponent } from './login/login-email/login-email.component';
import { LoginPasswordComponent } from './login/login-password/login-password.component';
import { MaterialModule } from '../../shared/layout/material/material.module';
import { AuthService } from './services/auth.service';
import { ComponentsModule } from 'src/app/shared/components/components.module';
import { UserService } from './services/user.service';

@NgModule({
  declarations: [LoginComponent, LoginEmailComponent, LoginPasswordComponent],
  imports: [
    CommonModule,
    RouterModule,
    AccountRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    ComponentsModule
  ],
  providers: [AuthService, UserService],
})
export class AccountModule {}
