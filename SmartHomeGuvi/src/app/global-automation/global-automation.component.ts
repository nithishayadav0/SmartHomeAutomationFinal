import { Component } from '@angular/core';
import { AutomationServiceService } from '../services/automation-service.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-global-automation',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './global-automation.component.html',
  styleUrl: './global-automation.component.css'
})
export class GlobalAutomationComponent {
  constructor(private automationService:AutomationServiceService){}
  automations: any[] = [];
  showForm: boolean = false;
  newAutomation: any = {
    triggerEvent: '',
    action: '',
    timeSchedule: '', // Default to "0 hours"
    status: '',
    description: '',
  };
  ngOnInit(): void {
    this.fetchAutomations();
  }

  fetchAutomations(): void {
    this.automationService.getAllAutomations().subscribe((data) => {
      this.automations = data;
    });
  }

  addAutomation(): void {
    this.automationService.addAutomation(this.newAutomation).subscribe(() => {
      this.fetchAutomations(); // Refresh list
      this.resetForm();
      this.showForm = false;
    });
  }

  resetForm(): void {
    this.newAutomation = {
      triggerEvent: '',
      action: '',
      timeSchedule: '',
      status: '',
      description: '',
    };
  }
  toggleForm() {
    this.showForm = !this.showForm; 
  }
}
