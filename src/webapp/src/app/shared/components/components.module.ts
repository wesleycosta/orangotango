import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MaterialModule } from '../layout/material/material.module';
import { ButtonComponent } from './button/button.component';

@NgModule({
  declarations: [ButtonComponent],
  imports: [CommonModule, MaterialModule],
  exports: [ButtonComponent],
})
export class ComponentsModule {}
