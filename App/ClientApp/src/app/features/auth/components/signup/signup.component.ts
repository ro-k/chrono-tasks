// signup.component.ts
import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {AuthService} from "../../services/auth.service";

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  constructor(private authService: AuthService) {
  }

  signupForm = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    email: new FormControl('', [Validators.email]),
    firstname: new FormControl(''),
    lastname: new FormControl(''),
  });

  onSubmit() {
    if (this.signupForm.valid) {
      console.log('Form Submitted', this.signupForm.value);
      this.authService.register(this.signupForm.value.username as string, this.signupForm.value.password as string, this.signupForm.value.email as string, this.signupForm.value.firstname as string, this.signupForm.value.lastname as string).subscribe({
        next: response => {
          console.log('Login successful:', response);
        },
        error: err => {
          console.error('Login error:', err);
        }
      });
    } else {
      console.log('Form is not valid');
    }
  }
}
