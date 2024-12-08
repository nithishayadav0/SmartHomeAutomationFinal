import { Component, OnInit } from '@angular/core';
import { AutomationServiceService } from '../services/automation-service.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
@Component({
  selector: 'app-automation',
  standalone: true,
  imports: [ CommonModule],
  templateUrl: './automation.component.html',
  styleUrl: './automation.component.css'
})
export class AutomationComponent implements OnInit {
  automations: any[] = [];
  errorMessage: string | null = null;

  constructor(private automationService: AutomationServiceService,private router:Router) {}

  ngOnInit(): void {
    this.automationService.getAutomations().subscribe(
      (data) => {
        console.log('Received response:', data);
        // this.roomNames = data.$values.map((room: any) => room.name);
        // this.roomId = data.$values.map((room: any) => room.roomId);
        this.automations=data
      },
      (error) => {
        console.error('Error fetching rooms:', error);
      }
    );
  }
  loadAutomations(): void {
    this.automationService.getAutomations().subscribe(
      (data) => {
        console.log(data);
        this.automations = data;
        console.log(this.automations);
      },
      (error) => {
        if (error.status === 401) {
          this.errorMessage = 'Unauthorized. Please login again.';
          // You could redirect to login page if needed
          this.router.navigate(['/login']);
        } else {
          this.errorMessage = error.message || 'Failed to load automations';
        }
      }
    );
  }
  deleteAutomation(automationId: number): void {
    this.automationService.deleteAutomation(automationId).subscribe(
      (response) => {
        // Remove the deleted automation from the local list
        this.automations = this.automations.filter(automation => automation.automationId !== automationId);
        alert('Automation deleted successfully!');
      },
      (error) => {
        console.error('Error deleting automation', error);
        alert('Failed to delete automation.');
      }
    );
  }
  
}
