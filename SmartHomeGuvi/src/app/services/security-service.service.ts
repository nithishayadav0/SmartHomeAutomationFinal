
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { LightboxServiceService } from './lightbox-service.service';

@Injectable({
  providedIn: 'root'
})
export class SecurityServiceService {
  // private securityStatus: string = 'Off';
  intervalId:any;
  showLightbox: boolean = false;
  private securityStatusSubject = new BehaviorSubject<string>('Off');
  private apiUrl = 'https://localhost:7175/api/Security/UpdateStatus'; 
  private apiGetUrl = 'https://localhost:7175/api/Security';
  private apiCurrentUrl = 'https://localhost:7175/api/Security/current-detections';

  constructor(private http: HttpClient,private lightboxService: LightboxServiceService) {}

  updateStatus(status: string): Observable<any> {
    const token = localStorage.getItem('authToken'); // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    return this.http.put<any>(`${this.apiUrl}/${status}`, null, { headers });
  }
  getAllSecurityDevices(): Observable<any[]> {
        
    const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
    const headers = new HttpHeaders()
    .set('Authorization', `Bearer ${token}`)
    .set('Content-Type', 'application/json');
    return this.http.get<any[]>(this.apiGetUrl, { headers });
  }
  
  // getSecurityStatus(): string {
  //   return this.securityStatus;
  // }

  // Method to update the status
  // setSecurityStatus(status: string): void {
  //   this.securityStatus = status;
  // }
  // setSecurityStatus(status: boolean): void {
  //   this.isSecurityActiveSubject.next(status);
  //   if (status) {
  //     // Start the interval when security is turned on
  //     this.startDetectionInterval();
  //   } else {
  //     // Clear the interval when security is turned off
  //     this.stopDetectionInterval();
  //   }
  // }

  getSecurityStatus(): Observable<string> {
    return this.securityStatusSubject.asObservable();
  }

  // Set and notify status change
  setSecurityStatus(status: string): void {
    this.securityStatusSubject.next(status);  // Notify all subscribers
  }

  getCurrentDetections(): Observable<string> {
    const token = localStorage.getItem('authToken'); // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get(this.apiCurrentUrl, { responseType: 'text' , headers: headers });
  }
  startDetectionCheck() {
    if (this.intervalId) return;

    this.intervalId = setInterval(() => {
      this.getCurrentDetections().subscribe({
        next: (detection: string) => {
          
          console.log('New detection:', detection);
          // alert(`New detection: ${detection}`);
          this.lightboxService.triggerDetection(detection);
        },
        error: (err) => console.error('Error fetching current detections:', err),
      });
    }, 30000); // Check every 30 seconds
  }

  stopDetectionCheck() {
    if (this.intervalId) {
      clearInterval(this.intervalId);
      this.intervalId = null;
    }
  }
  closeLightbox(): void {
    this.showLightbox = false;
  }

}
