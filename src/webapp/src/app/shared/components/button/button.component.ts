import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss'],
})
export class ButtonComponent {
  @Input() loading: boolean = false;

  @Input() text: string = '';

  @Input() color: string = 'primary';

  @Input() type: string = 'submit';

  @Output() clickEvent = new EventEmitter<void>();

  click(): void {
    this.clickEvent.emit();
  }
}
