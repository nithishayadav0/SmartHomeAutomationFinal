import { Component, OnInit } from '@angular/core';
import { RoomServiceService } from '../services/room-service.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthServiceService } from '../services/auth-service.service';
import { NavbarComponent } from '../navbar/navbar.component';
import { SecurityServiceService } from '../services/security-service.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule,FormsModule,NavbarComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit{
  roomNames: any[] = [];
  roomId:Number[]=[];
  showForm = false;
  userRole: 'Homeowner' | 'DeviceTechnician' | 'Guest' |'Administrator'|string;
  userName:string='';
  currentDate: string = new Date().toLocaleDateString();
  temperature: number = 22; 
  currentDetection: string = '';
  lastAlertMessage: string = '';
  
  newRoom = {
    name: '',
    floor: 0,
    zoneId: 0,
    roomType: '',
  };
  isKettleActive: boolean = false;
  isTvActive:boolean = false;
  isVaccumActive:boolean = false;
  isSecurityActive:boolean = false;
  successMessage = '';
  errorMessage = '';
  intervalId: any;
  constructor(private roomService: RoomServiceService ,private router:Router,private authService:AuthServiceService,private securityService: SecurityServiceService) {
    this.userRole = this.authService.getUserRole() || '';
  }
 
  ngOnInit(): void {
    // this.isSecurityActive = this.securityService.getSecurityStatus() === 'On';
    this.roomService.getRooms().subscribe(
      (data) => {
        console.log('Received response:', data);
        // this.roomNames = data.$values.map((room: any) => room.name);
        // this.roomId = data.$values.map((room: any) => room.roomId);
        this.roomNames=data
      },
      (error) => {
        console.error('Error fetching rooms:', error);
      }
    );
    this.userName=this.authService.getUserName(); 
   
    this.securityService.getSecurityStatus().subscribe((status: string) => {
      this.isSecurityActive = status === 'On';

      // Start or stop the detection check based on the security status
      if (this.isSecurityActive) {
        this.securityService.startDetectionCheck();
      } else {
        this.securityService.stopDetectionCheck();
      }
    });
  }
  ngOnDestroy(): void {
    if (this.intervalId) {
      clearInterval(this.intervalId);
    }
  }
  checkCurrentDetections(): void {
    this.securityService.getCurrentDetections().subscribe({
      next: (detection: string) => {
        if (detection && detection.trim() !== '') {
          this.currentDetection = detection; // Store the latest detection
        
          if (this.currentDetection !== this.lastAlertMessage) {
           
            this.lastAlertMessage = this.currentDetection; 
          }
        }
      },
      error: (err) => {
        console.error('Error fetching current detections:', err);
      }
    });
  }

 

  toggleKettle() {
    this.isKettleActive = !this.isKettleActive;
  }
  toggleTv() {
    this.isTvActive = !this.isTvActive;
  }
  
  toggleVaccum() {
    this.isVaccumActive = !this.isVaccumActive;
  }
  toggleSecurity(): void {
   
    this.isSecurityActive = !this.isSecurityActive;
    const status = this.isSecurityActive ? 'On' : 'Off';
    
    this.securityService.setSecurityStatus(status);
    if(status==='On'){
   
      this.intervalId = setInterval(() => {
        this.checkCurrentDetections();
      }, 30000);
    }
    this.securityService.updateStatus(status).subscribe({
      next: () => console.log(`Security status updated to: ${status}`),
      error: (error) => console.error('Error updating security status:', error)
    });
  
  }
  toggleForm(): void {
    this.showForm = !this.showForm;  
  }


  loadRooms(): void {
    this.roomService.getRooms().subscribe(
      (data) => {
        // this.roomNames = data.$values.map((room: any) => room.name);
        this.roomNames=data
      },
      (error) => {
        console.error('Error fetching rooms:', error);
      }
    );
  }
  
  onAddRoom(): void {
    this.roomService.addRoom(this.newRoom).subscribe(
      (response) => {
        this.successMessage = 'Room added successfully!';
        this.errorMessage = '';
        this.loadRooms();
        this.resetForm();
        this.showForm=!this.showForm;  
      },
      (error) => {
        this.errorMessage = 'Failed to add room. Please try again.';
        this.successMessage = '';
        console.error('Error:', error);
      }
    );
  }
 

  resetForm(): void {
    this.newRoom = {
      name: '',
      floor: 0,
      zoneId: 0,
      roomType: '',
    };
  }

  
  getBackgroundImage(roomName: string): string {
    if (roomName.toLowerCase() === 'bedroom') {
      return 'url(https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQipFiK07AHxC1VW3P3uF-ZnqWs3v3qsayWfQ&s)';
    } else if (roomName.toLowerCase() === 'kitchen') {
      return 'url(https://images.woodenstreet.de/image/data/modular%20kitchen/22.jpg)';
    } else if (roomName.toLowerCase() === 'living room') {
      return 'url(https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBmqNgjci6KnLjSU9WFIKi0Y8NiE6XOEVPMg&s)';
    } else {
      return 'url(https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcRYAjTYUMx_8bcqHO6vJF85xFGkeBUHk0Ln2Ix8-SWKXx9ypck1iQQNkygY28U9j5k8g63zx6giH88-wgQoew4RJ0ql_SaSRgDyqBqBcQY)';
    }
  }

  logout() {
    localStorage.removeItem('authToken');
    localStorage.removeItem('userRole');
    this.router.navigate(['/home']);
  }
  
  navigateToAddDevice(selectedRoomId: number) {
    this.router.navigate(['/add-device'],{ queryParams: { roomId: selectedRoomId } });
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
 
  navigateTomaintenaceList(){
    this.router.navigate(['/maintain-List']);
  }
  
}
