import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Category, defaultCategory} from "../../../../core/models/category";
import {CategoryStore} from "../../../../state/stores/category-store";

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.css']
})
export class CategoryFormComponent implements OnInit {
  @Input() category?: Category = undefined;
  @Output() hide = new EventEmitter();
  categoryForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private categoryStore: CategoryStore) {
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
        this.categoryStore.update(this.category);
      } else {
        this.category = {...defaultCategory,name,description};
        this.categoryStore.add(this.category);
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


