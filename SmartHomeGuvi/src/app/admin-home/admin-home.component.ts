import { Component } from '@angular/core';
import {Router} from '@angular/router'
@Component({
  selector: 'app-admin-home',
  standalone: true,
  imports: [],
  templateUrl: './admin-home.component.html',
  styleUrl: './admin-home.component.css'
})
export class AdminHomeComponent {
  constructor(private router:Router){}
  navigateToTechnicians() {
    this.router.navigate(['/administrator'], { queryParams: { role: 'Technician' } });
  }

  navigateToUsers() {
    this.router.navigate(['/administrator'], { queryParams: { role: 'User' } });
  }
  logout(){
    localStorage.removeItem('authToken');
      localStorage.removeItem('userRole');
      this.router.navigate(['/home']);
  }
}
