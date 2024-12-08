import { Component, OnInit } from '@angular/core';
import { NotificationServiceService } from '../services/notification-service.service';
import { CommonModule } from '@angular/common';
import { SecurityServiceService } from '../services/security-service.service';
@Component({
  selector: 'app-notifications',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './notifications.component.html',
  styleUrl: './notifications.component.css'
})
export class NotificationsComponent implements OnInit {
  constructor(private notificationService:NotificationServiceService,private securityService: SecurityServiceService){}
  notifications: any[] = [];
  notifyCount: number = 0;
  private lastAlertMessage: string = '';
  securityDevices: any[] = []; // Array to hold the security devices data
 
  ngOnInit(): void {
    this.loadNotifications();  
    this.fetchSecurityDevices();
    
  }

  loadNotifications(): void {
    this.notificationService.getNotifications().subscribe(
      (data) => {
        // this.roomNames = data.$values.map((room: any) => room.name);
        
        this.notifications=data.notifications;
        this.notifyCount=this.notifications.length;
        this.notificationService.updateNotifyCount(this.notifyCount);
        console.log(this.notifications);
      },
      (error) => {
        console.error('Error fetching rooms:', error);
      }
    );
  }
  deleteNotification(notificationId: number): void {
    this.notificationService.deleteNotification(notificationId).subscribe(
      () => {
        
        this.notifications = this.notifications.filter(
          (n) => n.notificationId !== notificationId
        );
        console.log(`Notification ${notificationId} deleted successfully.`);
      },
      (error) => {
        console.error(`Error deleting notification ${notificationId}:`, error);
      }
    );
  }



  fetchSecurityDevices(): void {
    this.securityService.getAllSecurityDevices().subscribe({
      next: (devices) => {
        console.log(devices);
        this.securityDevices = devices; 
        
      },
      error: (err) => {
        console.error('Error fetching security devices:', err);
      },
    });
  }
  checkCurrentDetections(): void {
    this.securityService.getCurrentDetections().subscribe({
      next: (detections: string) => {
        if (detections && detections.length > 0) {
          const currentMessage = detections;
          // Compare with the last alert message to avoid repeating
          if (currentMessage !== this.lastAlertMessage) {
            this.showAlert(detections);
            this.lastAlertMessage = currentMessage; // Update the last alert message
          }
        }
      },
      error: (err) => {
        console.error('Error fetching current detections:', err);
      }
    });
  }
  showAlert(detections: string): void {
    const message = detections;
    alert(`Security Alert:\n${message}`);
  }
}
