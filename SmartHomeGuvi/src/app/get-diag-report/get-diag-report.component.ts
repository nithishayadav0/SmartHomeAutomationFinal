import { Component, OnInit } from '@angular/core';
import { DeviceServiceService } from '../services/device-service.service';
import { DeviceMainService } from '../services/device-main.service';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-get-diag-report',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './get-diag-report.component.html',
  styleUrl: './get-diag-report.component.css'
})
export class GetDiagReportComponent implements OnInit {
constructor(private deviceMainService:DeviceMainService,private route:ActivatedRoute){}
deviceId:number=0;
diagnosticsReport: any;

responseMessage: string | null = null;
ngOnInit(): void {
  
    
  this.route.queryParams.subscribe(params => {
    this.deviceId = +params['deviceId']; 
  });
  this.GetDiagnostics();
}
 
  GetDiagnostics(): void {
    this.deviceMainService.GetDiagnostics(this.deviceId).subscribe(
      (data) => {
        this.diagnosticsReport = data;
      },
      (error) => {
        console.error('Error running diagnostics:', error);
      }
    );
  }

  updateDiagnostics():void {
    this.deviceMainService.updateDiagnostics(this.deviceId, this.diagnosticsReport).subscribe(
      (response) => {
        this.responseMessage = response.message;
      },
      (error) => {
        this.responseMessage = error.error.message || 'An error occurred.';
      }
    );
  }
}
