import {Component, EventEmitter, Input, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {defaultJob, Job} from "../../../../core/models/job";
import {JobStore} from "../../../../state/stores/job-store";
import {ContentViewItem} from "../../../../core/models/content-view-item";

@Component({
  selector: 'app-job-form',
  templateUrl: './job-form.component.html',
  styleUrl: './job-form.component.css'
})
export class JobFormComponent {
  @Input() job?: Job = undefined;
  @Input() parentItem?: ContentViewItem = undefined;
  @Output() hide = new EventEmitter();
  jobForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private jobStore: JobStore) {
  }

  ngOnInit(){
    this.jobForm = this.formBuilder.group({
      name: [this.job?.name || '', Validators.required],
      description: [this.job?.description || '']
    });
  }

  onSave() {
    if (this.jobForm.valid) {
      // Accessing form values
      const formData = this.jobForm.value;

      // formData now contains the values of the title and description fields
      const name = formData.name;
      const description = formData.description;
      let adding = false;

      if(this.job == undefined) {
        this.job = {...defaultJob};
        adding = true;
      }

      this.job.categoryId = this.parentItem?.id ?? "";
      this.job.name = name;
      this.job.description = description;
      this.job.data = '{}';

      if(adding) {
        this.jobStore.add(this.job);
      } else {
        this.jobStore.update(this.job);
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
