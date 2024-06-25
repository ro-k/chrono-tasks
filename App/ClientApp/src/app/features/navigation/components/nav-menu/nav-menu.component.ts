import { Component } from '@angular/core';
import {UserStore} from "../../../../state/stores/user-store";
import {Router} from "@angular/router";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private userStore: UserStore, private router: Router) {
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.userStore.logout().subscribe({
      next: () => this.router.navigate(['/login']).then(success => {
        if (!success) {
          console.error('Navigation to login failed!');
        }
      })
    });
  }
}
