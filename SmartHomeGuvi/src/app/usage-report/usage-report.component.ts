import { Component, OnInit } from '@angular/core';
import { UsageServiceService } from '../services/usage-service.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthServiceService } from '../services/auth-service.service';
import { NavbarComponent } from '../navbar/navbar.component';


@Component({
  selector: 'app-usage-report',
  standalone: true,
  imports: [CommonModule,FormsModule, NavbarComponent],
  templateUrl: './usage-report.component.html',
  styleUrl: './usage-report.component.css'
})
export class UsageReportComponent implements OnInit {
  constructor(private usageService:UsageServiceService,private authService:AuthServiceService){}
  report: any[] = [];
  totalConsumption: number = 0;
  totalCost: number = 0;
  userEmail: string = '';
  monthlyReports: any[] = [];
  errorMessage: string = '';
  userRole:string=''; 
  ngOnInit(): void {
    this.loadRooms();
    this.userRole = this.authService.getUserRole();
    // this.updateChartData();

    this.usageService.userEmail$.subscribe(userEmail => {
      if (userEmail) {
        this.userEmail = userEmail;
        this.fetchMonthlyEnergyReport();
      }
    });
  }

  loadRooms(): void {
    this.usageService.getReport().subscribe(
      (data) => { 
        this.report=data
        this.calculateTotals(); 
        console.log(this.report);
      },
      (error) => {
        console.error('Error fetching rooms:', error);
      }
    );
  }
  calculateTotals(): void {
    this.totalConsumption = this.report.reduce((acc, item) => acc + item.totalConsumption, 0);
    this.totalCost = this.report.reduce((acc, item) => acc + item.totalCost, 0);
  }
  fetchMonthlyEnergyReport(): void {
    if (this.userEmail) {
      this.usageService.getMonthlyEnergyReport(this.userEmail).subscribe({
        next: (data) => {
          this.monthlyReports = data;
        },
        error: (err) => {
          this.errorMessage = 'Error fetching the data';
          console.error(err);
        }
      });
    }
  }
  // public barChartOptions: ChartOptions = {
  //   responsive: true,
  // };
  // public barChartLabels: string[] = [];  // Use string[] instead of Label[]
  // public barChartData: ChartDataset[] = [
  //   { data: [], label: 'Power Consumption (kWh)' }
  // ];
  // public barChartType: ChartType = 'bar';
  //  updateChartData(): void {
  //   this.barChartLabels = this.report.map(item => item.deviceName);
  //   this.barChartData[0].data = this.report.map(item => item.totalConsumption);
  // }
  // public barChartData: ChartDataset[] = [
  //   { data: [65, 59, 80, 81, 56, 55, 40], label: 'Series A' }
  // ];
  // public barChartLabels: string[] = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];
  // public barChartOptions: ChartOptions = {
  //   responsive: true,
  // };
  // public barChartType: ChartType = 'bar';
  // public barChartColors = [
  //   {
  //     backgroundColor: 'rgba(255, 99, 132, 0.2)',
  //   },
  // ];
}
