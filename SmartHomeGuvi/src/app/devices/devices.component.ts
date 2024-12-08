import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DeviceServiceService } from '../services/device-service.service';
import { ActivatedRoute,Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms'; 
import { AuthServiceService } from '../services/auth-service.service';
import { DeviceMainService } from '../services/device-main.service';
import { NavbarComponent } from '../navbar/navbar.component';
@Component({
  selector: 'app-devices',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,NavbarComponent ],
  templateUrl: './devices.component.html',
  styleUrl: './devices.component.css'
})
export class DevicesComponent implements OnInit {
  deviceId:number=0;
  deviceForm!: FormGroup;
  roomId: number = 0; // Room ID passed from the query params
  userRole:string='';
  diagnosticsForm!: FormGroup;
  showModal = false;
  devices: any[] = [];
  errorMessage: string = '';
  showLightbox: boolean = false; 
  responseMessage:string=''
  showDeviceForm: boolean = false;
  constructor(
    private fb: FormBuilder,
    private deviceService: DeviceServiceService, 
    private authService :AuthServiceService,
    private deviceMainService:DeviceMainService,
    private route: ActivatedRoute  ,// To get query params
    private router:Router,
  ) {}
  
  ngOnInit(): void {
    this.userRole = this.authService.getUserRole();
    // Get roomId from the query params
    this.route.queryParams.subscribe(params => {
      this.roomId = params['roomId']; // Assuming the roomId is passed as a query parameter
      this.loadDevices();
    });
  
    // Initialize the form without the roomId field
    this.deviceForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(100)]],
      type: ['', [Validators.required, Validators.maxLength(50)]],
      location: ['', [Validators.maxLength(100)]],
      status: ['', [Validators.required, Validators.maxLength(50)]],
      configurationSettings: [''],
      lastUpdated: ['', Validators.required],
    });
    this.diagnosticsForm = this.fb.group({
      batteryLevel: ['', [Validators.required]],
      connectivityStatus: ['', [Validators.required]],
      firmwareVersion: ['', [Validators.required]],
      lastUpdated: [new Date().toISOString(), [Validators.required]],
    });
   
  }

  loadDevices(): void {
    this.deviceService.getDevicesByRoomId(this.roomId).subscribe(
      (data) => {
        console.log('Devices fetched:', data);
        this.devices = data;
      },
      (error) => {
        console.error('Error fetching devices:', error);
        this.errorMessage = 'Failed to load devices. Please try again later.';
      }
    );
  }
 
  toggleLightbox(): void {
    this.showLightbox = !this.showLightbox;
  }
  openDeviceForm() {
    this.showDeviceForm = true;
  }

  // Close the Add Device form (lightbox)
  closeDeviceForm() {
    this.showDeviceForm = false;
  }
  onSubmit(): void {
    if (this.deviceForm.valid) {
      // Add the roomId from query params to the form data before submitting
     
      const formData = { ...this.deviceForm.value };  // Do not need to add roomId here, it's passed as a query param
     
      // Call the service to send data to the backend with roomId as query param
      this.deviceService.addDevice(formData, this.roomId).subscribe(response => {
        console.log('Device added successfully', response);
        this.loadDevices();
        this.toggleLightbox(); 
        // Handle success (e.g., show a success message or navigate)
      }, error => {
        console.error('Error adding device', error);
        // Handle error (e.g., show an error message)
      });
    } else {
      console.log('Form is invalid');
    }
  }
  onSubmitDiagForm(): void {
    if (this.diagnosticsForm.valid && this.deviceId !== null) {
      const formData = this.diagnosticsForm.value;
      this.deviceMainService.updateDiagnostics(this.deviceId, formData).subscribe(
        (response) => {
          this.responseMessage = 'Diagnostics updated successfully!';

          this.closeModal(); // Close the modal upon success
          this.router.navigate(['/GetDiagReport'],{ queryParams: { deviceId: this.deviceId }})
        },
        (error) => {
          this.responseMessage = error.error.message || 'An error occurred.';
        }
      );
    }
  }
  get formControls() {
    return this.deviceForm.controls;
  }
  toggleStatus(device: any): void {
    // Toggle the status between 'On' and 'Off'
    device.status = device.status === 'On' ? 'Off' : 'On';

    // Set the LastUpdated field to current date and time
    

    // Call the service to update the device status in the backend
    this.deviceService.updateDeviceStatus(device).subscribe(
      (updatedDevice) => {
        console.log('Device status updated', updatedDevice);
      },
      (error) => {
        console.error('Error updating device status', error);
        // Optionally revert the status change if there was an error
        device.status = device.status === 'On' ? 'Off' : 'On';
      }
    );
  }
  toggleSpeed(device: any): void {
    // Toggle the status between 'On' and 'Off'
    device.configurationSettings  = device.configurationSettings  === 'High' ? 'Low' : 'High';

    // Set the LastUpdated field to current date and time
    

    // Call the service to update the device status in the backend
    this.deviceService.updateDeviceStatus(device).subscribe(
      (updatedDevice) => {
        console.log('Device status updated', updatedDevice);
      },
      (error) => {
        console.error('Error updating device status', error);
        // Optionally revert the status change if there was an error
        device.status = device.status === 'On' ? 'Off' : 'On';
      }
    );
    this.deviceService.updateDeviceSpeed(device).subscribe(
      (updatedDevice) => {
        console.log('Device status updated', updatedDevice);
      },
      (error) => {
        console.error('Error updating device status', error);
        // Optionally revert the status change if there was an error
        device.status = device.status === 'On' ? 'Off' : 'On';
      }
    );
  }
  


   
  navigateToAddActivation(selecteddeviceId: number) {
    this.router.navigate(['/add-activation'],{ queryParams: { deviceId: selecteddeviceId } });
  }
  navigateTosendMaintenance(deviceId: number) {
    this.router.navigate(['/send-maintenance'],{ queryParams: { deviceId: deviceId } });
  }
  navigateToDiagnosticsReport(deviceId:number){
    this.router.navigate(['/GetDiagReport'],{ queryParams: { deviceId: deviceId } });
  }
  navigateToupdateDiagnostics(deviceId: number): void {
    this.deviceId = deviceId;
    this.showModal = true; // Show the lightbox when button is clicked
  }
  closeModal(): void {
    this.showModal = false;
  }
}
