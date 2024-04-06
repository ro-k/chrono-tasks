import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Category} from "../../../../core/models/category";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {defaultJob, Job} from "../../../../core/models/job";
import {JobStore} from "../../../../state/stores/job-store";

@Component({
  selector: 'app-job-form',
  templateUrl: './job-form.component.html',
  styleUrl: './job-form.component.css'
})
export class JobFormComponent {
  @Input() job?: Job = undefined;
  @Input() parentCategory?: Category = undefined;
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

      if (this.job) {
        this.job.categoryId = this.parentCategory?.categoryId ?? "";
        this.job.name = name;
        this.job.description = description;
        this.jobStore.update(this.job);
      } else {
        this.job = {...defaultJob,name,description};
        this.jobStore.add(this.job);
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
