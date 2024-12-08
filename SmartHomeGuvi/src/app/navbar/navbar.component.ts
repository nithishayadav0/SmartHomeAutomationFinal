import { Component, OnInit } from '@angular/core';
import {Router } from '@angular/router'
import { AuthServiceService } from '../services/auth-service.service';
import { NotificationServiceService } from '../services/notification-service.service';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [ CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit{
  userName:string='';
  notifyCount: number = 0;
  constructor(private router:Router,private authService:AuthServiceService,private notificationService:NotificationServiceService){}
  ngOnInit():void{
    this.userName=this.authService.getUserName();

      this.notificationService.currentNotifyCount.subscribe(count => {
        this.notifyCount = count;
        console.log(this.notifyCount);
      })
     
  }
  navigateToAutomations(): void {
    this.router.navigate(['/automations']);  
  }
  navigateToUsageReport(): void {
    this.router.navigate(['/usage-report']);  
  }
  navigateToNotifications(): void {
    this.router.navigate(['/notifications']);  
  }
  logout() {
    localStorage.removeItem('authToken');
    localStorage.removeItem('userRole');
    this.router.navigate(['/home']);
  }
  navigateTomaintenaceList(){
    this.router.navigate(['/maintain-List']);
  }
  navigateToUserProfile(){
    this.router.navigate(['/user-profile']);
  }
  isMenuOpen = false;


}
