import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AutomationServiceService } from '../services/automation-service.service';
import { Router,ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

import { ReactiveFormsModule } from '@angular/forms'
@Component({
  selector: 'app-add-activation',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule ],
  templateUrl: './add-activation.component.html',
  styleUrl: './add-activation.component.css'
})
export class AddActivationComponent implements OnInit{
  automationForm!: FormGroup;
  deviceId: number=0;
  selectedTriggerEvent: string = '';

  constructor(
    private fb: FormBuilder,
    private automationService: AutomationServiceService,
    private router: Router,
    private route:ActivatedRoute
  ) { }

  ngOnInit(): void {
    // Initialize the form
    this.automationForm = this.fb.group({
      triggerEvent: ['', Validators.required],
      action: ['', Validators.required],
      timeSchedule: ['', Validators.required],
      status: ['Pending', Validators.required]
    
    });


      // Get the deviceId from query parameters
      this.route.queryParams.subscribe(params => {
        this.deviceId = +params['deviceId'];  // Ensure the deviceId is a number
      });
  }

  // Submit the form
  onSubmit(): void {
    if (this.automationForm.valid) {
      const automationData = { ...this.automationForm.value, deviceId: this.deviceId };

      this.automationService.createAutomation(automationData).subscribe(
        (response) => {
          console.log('Automation created successfully:', response);
          this.router.navigate(['/automations']); // Navigate to automations list or another page
        },
        (error) => {
          console.error('Error creating automation:', error);
        }
      );
    } else {
      console.log('Form is invalid');
    }
  }
  onTriggerEventChange(event: Event): void {
    this.selectedTriggerEvent = (event.target as HTMLSelectElement).value;
  }

}
