import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss'],
})
export class ButtonComponent {
  @Input() color: string = 'primary';

  @Input() loading: boolean = false;

  @Input() type: string = 'button';

  @Output() click = new EventEmitter<void>();

  onClick(): void {
    this.click.emit();
  }
}
