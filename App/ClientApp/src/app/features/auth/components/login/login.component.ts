import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {UserStore} from "../../../../state/stores/user-store";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  errorMessage = '';

  constructor(private userStore: UserStore, private router: Router) {
  }

  loginForm = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });

  onSubmit() {
    if (this.loginForm.valid) {
      console.log('Form Submitted', this.loginForm.value);
      this.errorMessage = '';
      this.userStore.login(this.loginForm.value.username as string, this.loginForm.value.password as string).subscribe({
          next: () => {
            this.router.navigate(['/']).then(success => {
              if (!success) {
                console.error('Navigation to home failed!');
              }
            });
          },
          error: () => {
            this.errorMessage = 'Login failed';
          }
        }
      );
    } else {
      console.log('Form is not valid');
    }
  }

  onSignUp()
  {
    this.router.navigate(['/signup']).then();
  }
}
