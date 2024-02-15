import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-nothing-here',
  templateUrl: './nothing-here.component.html',
  styleUrls: ['./nothing-here.component.css']
})
export class NothingHereComponent {
  @Input() items: any[] = [];
}
