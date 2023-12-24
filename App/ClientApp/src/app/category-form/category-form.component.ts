import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Category, defaultCategory} from "../shared/models/category";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.css']
})
export class CategoryFormComponent implements OnInit {
  @Input() category?: Category = undefined;
  @Output() save = new EventEmitter<Category>();
  @Output() cancel = new EventEmitter<void>();
  categoryForm!: FormGroup;

  constructor(private formBuilder: FormBuilder) {
  }

  ngOnInit(){
    this.categoryForm = this.formBuilder.group({
      name: [this.category?.name || '', Validators.required],
      description: [this.category?.description || '']
    });
  }

  onSave() {
    if (this.categoryForm.valid) {
      // Accessing form values
      const formData = this.categoryForm.value;

      // formData now contains the values of the title and description fields
      const name = formData.name;
      const description = formData.description;

      if (this.category) {
        this.category.name = name;
        this.category.description = description;
      } else {
        this.category = {...defaultCategory,name,description};
      }

      this.save.emit(this.category);
    } else {
      // Handle form validation errors
    }
  }

  onCancel() {
    this.cancel.emit();
  }
}


