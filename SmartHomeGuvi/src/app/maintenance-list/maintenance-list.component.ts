import { Component, OnInit } from '@angular/core';
import { DeviceMainService } from '../services/device-main.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-maintenance-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './maintenance-list.component.html',
  styleUrl: './maintenance-list.component.css'
})
export class MaintenanceListComponent implements OnInit{

  maintenanceRequests: any[] = []; // Array to store maintenance requests
  errorMessage: string = ''; // To store error messages

  constructor(
    
    private deviceMainService: DeviceMainService,
    private router: Router,
    private route:ActivatedRoute
  ) { }
  ngOnInit(): void {
  
    this.fetchMaintenanceRequests();
}
  fetchMaintenanceRequests(): void {
    this.deviceMainService.getMaintenanceRequests().subscribe(
      (data) => {
        this.maintenanceRequests = data;
      },
      (error) => {
        this.errorMessage = 'Failed to load maintenance requests. Please try again later.';
      }
    );
  }
}
