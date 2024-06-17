// signup.component.ts
import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {UserStore} from "../../../../state/stores/user-store";
import {Router} from "@angular/router";

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent {
  errorMessage = '';

  constructor(private userStore: UserStore, private router: Router) {
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
      this.userStore.register({username: this.signupForm.value.username as string, password: this.signupForm.value.password as string, email: this.signupForm.value.email as string, firstname: this.signupForm.value.firstname as string, lastname: this.signupForm.value.lastname as string}).subscribe({
          next: () => {
            this.router.navigate(['/']).then(success => {
              if (!success) {
                console.error('Navigation to home failed!');
              }
            });
          },
          error: () => {
            this.errorMessage = 'Registration failed';
          }
        }
      );
    } else {
      console.log('Form is not valid');
    }
  }
}
