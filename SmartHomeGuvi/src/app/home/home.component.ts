import { Component } from '@angular/core';
import { UserComponent } from '../user/user.component';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [UserComponent,CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  buttonClicked = false;
  
  constructor(private router: Router) {}
  ngOnInit(): void {

    this.buttonClicked = false;
  }
  navigateTo(route: string): void {
    this.buttonClicked = true; 
    this.router.navigate([`/${route}`]);
  }
  // navigateToDevices() {
  //   this.router.navigate(['/devices']);
  // }
}
