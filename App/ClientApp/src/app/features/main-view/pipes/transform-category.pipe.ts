import { Pipe, PipeTransform } from '@angular/core';
import {TreeViewCategory} from "../../../core/models/tree-view-category";
import {ContentViewItem} from "../../../core/models/content-view-item";

@Pipe({
  name: 'transformCategory',
})
export class TransformCategoryPipe implements PipeTransform {

  transform(value: TreeViewCategory, args?: any[]): ContentViewItem {
    return {createdAt: value.createdAt, description: value.description ?? "", id: value.categoryId, modifiedAt: value.modifiedAt, name: value.name, type: value.type};
  }
}
