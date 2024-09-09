import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-nothing-here',
  templateUrl: './nothing-here.component.html',
  styleUrls: ['./nothing-here.component.scss']
})
export class NothingHereComponent {
  // @Input() items: ArrayWrapper<any> = {items: []};
  @Input() items: any[] = [];
}
