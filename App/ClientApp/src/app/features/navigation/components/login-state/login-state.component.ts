import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {UserDto} from "../../../../core/models/user-dto";
import {UserStore} from "../../../../state/stores/user-store";
import {firstValueFrom} from "rxjs";

@Component({
  selector: 'app-login-state',
  templateUrl: './login-state.component.html',
  styleUrls: ['./login-state.component.scss']
})
export class LoginStateComponent implements OnInit {
  user: UserDto | undefined;

  constructor(private router: Router, private userStore: UserStore) {
    userStore.user$.subscribe(user => this.user = user);
  }

  ngOnInit(): void {
  }

  login(): void {
    this.router.navigate(['/login']).then();
  }

  viewProfile(): void {
    this.router.navigate(['/profile']).then();
  }

  async logout(): Promise<void> {
    await firstValueFrom(this.userStore.logout());
    await this.router.navigate(['/login']);
  }

  getInitials(): string {
    return this.user != null ? (this.user.firstName[0] + this.user.lastName[0]).toUpperCase() : '';
  }

  combineUserName() {
    return this.user != null ? (this.user.firstName + ' ' + this.user.lastName).trim() : '';
  }
}
