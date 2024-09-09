import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-edit-dialog',
  templateUrl: './edit-dialog.component.html',
  styleUrl: './edit-dialog.component.scss'
})
export class EditDialogComponent {
  @Output() onCancel = new EventEmitter();
  @Output() onSave = new EventEmitter();
  @Input() title = '';

}
