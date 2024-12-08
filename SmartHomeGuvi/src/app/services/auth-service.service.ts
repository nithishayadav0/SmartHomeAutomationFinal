import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  private userData: any = null;

  constructor(private http: HttpClient) {}
  getUserRole(): string {
    return localStorage.getItem('userRole') || ''; // Return the stored role or an empty string
  }
  getUserName():string{
    return localStorage.getItem('userName') || '';
  }
  isUserHomeOwner(): boolean {
    return this.getUserRole() === 'Homeowner';
  }

  isUserDeviceTechnician(): boolean {
    return this.getUserRole() === 'DeviceTechnician';
  }
  setUserData(data: any): void {
    this.userData = data;
  }

  // Method to get user data
  getUserData(): any {
    return this.userData;
  }
  private apiUrl =  'https://localhost:7175/api/User'

 
  // Method to update user data
  updateUser(userId: number, updatedUser: any): Observable<any> {
    const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.put(this.apiUrl, updatedUser,{ headers: headers });
  }
}
