import {Component, EventEmitter, Input, Output} from '@angular/core';
import {defaultJob} from "../../../../core/models/job";
import {ContentViewItem} from "../../../../core/models/content-view-item";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Activity, defaultActivity} from "../../../../core/models/activity";
import {ActivityStore} from "../../../../state/stores/activity-store";
import {ItemType} from "../../../../core/models/item-type";

@Component({
  selector: 'app-activity-form',
  templateUrl: './activity-form.component.html',
  styleUrl: './activity-form.component.css'
})
export class ActivityFormComponent {
  @Input() activity?: Activity = undefined;
  @Input() parentItem?: ContentViewItem = undefined;
  @Output() hide = new EventEmitter();
  activityForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private activityStore: ActivityStore) {
  }

  ngOnInit(){
    this.activityForm = this.formBuilder.group({
      name: [this.activity?.name || '', Validators.required],
      description: [this.activity?.description || '']
    });
  }

  onSave() {
    if (this.activityForm.valid) {
      // Accessing form values
      const formData = this.activityForm.value;

      // formData now contains the values of the title and description fields
      const name = formData.name;
      const description = formData.description;
      let adding = false;

      if (this.activity == undefined) {
        this.activity = {...defaultActivity };
        adding = true;
      }

      console.log(this.parentItem);
      if(this.parentItem?.type === ItemType.Job) {
        this.activity.jobId = this.parentItem.id;
      }
      else if(this.parentItem?.type === ItemType.Category) {
        this.activity.categoryId = this.parentItem.id;
      }

      this.activity.name = name;
      this.activity.description = description;
      console.log(this.activity);

      if(adding) {
        this.activityStore.add(this.activity);
      } else {
        this.activityStore.update(this.activity);
      }


      this.hide.emit();
    } else {
      // Handle form validation errors
    }
  }

  onCancel() {
    this.hide.emit();
  }
}
