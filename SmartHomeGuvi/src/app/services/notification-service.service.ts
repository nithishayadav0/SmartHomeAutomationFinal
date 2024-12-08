import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotificationServiceService {


  private apiUrl = 'https://localhost:7175/api/Notifications';
  private notifyCountSource = new BehaviorSubject<number>(0);
  currentNotifyCount = this.notifyCountSource.asObservable(); 

  constructor(private http: HttpClient) {}


  // Update the notify count
  updateNotifyCount(count: number): void {
    this.notifyCountSource.next(count);
  }
  
  getNotifications(): Observable<any> {
    
    const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<any>(this.apiUrl, { headers: headers });    
  }
  deleteNotification(notificationId: number): Observable<void> {
    const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.delete<void>(`${this.apiUrl}/${notificationId}`, { headers: headers });
  }

}
