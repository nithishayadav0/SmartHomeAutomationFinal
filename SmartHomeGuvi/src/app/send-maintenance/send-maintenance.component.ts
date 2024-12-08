import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { DeviceMainService } from '../services/device-main.service';
import { Router,ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-send-maintenance',
  standalone: true,
  imports: [CommonModule,FormsModule ],
  templateUrl: './send-maintenance.component.html',
  styleUrl: './send-maintenance.component.css'
})
export class SendMaintenanceComponent implements OnInit {
  maintenanceRequest: Partial<any> = {
    maintenanceType: '',
  
  };
  
  deviceId:number=0;
  constructor(
    private fb: FormBuilder,
    private deviceMainService: DeviceMainService,
    private router: Router,
    private route:ActivatedRoute
  ) { }
  
  ngOnInit(): void {
  
    
      this.route.queryParams.subscribe(params => {
        this.deviceId = +params['deviceId']; 
      });
   
  }
  onSubmit(): void {
    this.deviceMainService
      .createMaintenanceRequest(this.deviceId, this.maintenanceRequest)
      .subscribe({
        next: (response) => {
          console.log('Maintenance request created successfully:', response);
          alert('Request created successfully!');
          this.router.navigate(['/maintain-List']); // Adjust route as needed
        },
        error: (error) => {
          console.error('Error creating maintenance request:', error);
          alert('Failed to create maintenance request.');
        },
      });
    }
    
  
  }
