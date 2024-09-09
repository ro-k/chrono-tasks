import {Component, EventEmitter, Output} from '@angular/core';
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-back',
  templateUrl: './back.component.html',
  styleUrl: './back.component.scss'
})
export class BackComponent {
 @Output() clickEvent = new EventEmitter();
}
