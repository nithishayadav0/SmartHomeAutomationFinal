import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserComponent } from './user/user.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import {FormsModule } from '@angular/forms'
import { TechHomeComponent } from './tech-home/tech-home.component';
import { AuthServiceService } from './services/auth-service.service';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CommonModule } from '@angular/common';
import { SecurityServiceService } from './services/security-service.service';
import { SecurityLightboxComponent } from './security-lightbox/security-lightbox.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,UserComponent,ReactiveFormsModule,HomeComponent,FormsModule, TechHomeComponent,DashboardComponent,CommonModule,SecurityLightboxComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'smart-home';
  userRole: string = '';
  latestDetection: string = '';
  private detectionInterval: any;

  constructor(private authService: AuthServiceService,private securityService:SecurityServiceService) {}

  ngOnInit() {
    this.userRole = this.authService.getUserRole();
   
    
  }
 
  }