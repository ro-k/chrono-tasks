import { Component, Input } from '@angular/core';
import { Folder } from '../shared/models/folder';

@Component({
  selector: 'app-tree-view',
  templateUrl: './tree-view.component.html',
  styleUrls: ['./tree-view.component.css']
})
export class TreeViewComponent {
  @Input() folders: Folder[] = [];
}
