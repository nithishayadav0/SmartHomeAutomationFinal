import { Component, OnInit } from '@angular/core';
import { MaintenanceListComponent } from '../maintenance-list/maintenance-list.component';
import { DeviceMainService } from '../services/device-main.service';
import { CommonModule } from '@angular/common';
import { UserService } from '../services/UserService.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { RoomServiceService } from '../services/room-service.service';
import { AuthServiceService } from '../services/auth-service.service';
@Component({

  selector: 'app-tech-home',
  standalone: true,
  imports: [MaintenanceListComponent,CommonModule ,FormsModule ],
  templateUrl: './tech-home.component.html',
  styleUrl: './tech-home.component.css'
})
export class TechHomeComponent implements OnInit{
  maintenanceList: any[] = []; 
  userList:any[]=[];
  errorMessage:string='';
  isLightboxVisible = false; 
  userName:string='';
  userData = {
    username: '',
    useremail: ''
  };
  constructor(private deviceMainService:DeviceMainService,private userService:UserService,private router:Router,private roomService:RoomServiceService,private authService:AuthServiceService){}
  ngOnInit(): void {
    
    this.fetchMaintenanceRequests();
    this.userName=this.authService.getUserName();
}
  fetchMaintenanceRequests(): void {
    this.deviceMainService.getAllMaintenanceRequests().subscribe(
      (data) => {
        this.maintenanceList = data;
      },
      (error) => {
        this.errorMessage = 'Failed to load maintenance requests. Please try again later.';
      }
    );
  }
  toggleStatus(maintenance: any): void {
    const newStatus = maintenance.status.toLowerCase() === "pending" ? "completed" : "pending";
    console.log(newStatus,maintenance.maintenanceId)
    this.deviceMainService.updateStatus(maintenance.maintenanceId, newStatus).subscribe(
      response => {
        maintenance.status = newStatus;  // Update the status in the UI
        console.log(response.message);  // Optional: log the success message
        // No need to refetch the list if only one item has changed, can just update the status in maintenanceList
      },
      error => {
        console.error('Error updating status:', error);
      }
    );
  }
 
    navigateToUsers(){
      this.router.navigate(['/UserList']);
    }
 
  
    openLightbox() {
      this.isLightboxVisible = true;
    }
  
    closeLightbox() {
      this.isLightboxVisible = false;
    }
    onSubmit() {
      const { username, useremail } = this.userData;
  
      if (username && useremail) {
        this.roomService.getRoomsByUsernameAndEmail(username, useremail).subscribe({
          next: (response) => {
            console.log('Rooms:', response);
           
            this.router.navigate(['/tech-rooms'], {
              queryParams: { username: username, useremail: useremail }
            });
            this.closeLightbox();  // Close the lightbox after successful submission
          },
          error: (error) => {
            console.error('Error fetching rooms:', error);
            // handle the error (e.g., show error message)
          }
        });
      } else {
        console.log('Please provide both username and email');
      }
}
logout(){
  localStorage.removeItem('authToken');
    localStorage.removeItem('userRole');
    this.router.navigate(['/home']);
}
}