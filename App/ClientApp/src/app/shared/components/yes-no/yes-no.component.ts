import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-yes-no',
  templateUrl: './yes-no.component.html',
  styleUrls: ['./yes-no.component.css']
})
export class YesNoComponent {
  @Input() message: string = 'Are you sure?';
  @Output() yes = new EventEmitter<void>();
  @Output() no = new EventEmitter<void>();

  onYes() {
    this.yes.emit();
  }

  onNo() {
    this.no.emit();
  }
}
