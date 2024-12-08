import { Injectable } from '@angular/core';
import { User } from '../Models/user';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
 
  
  private apiUrl = 'https://localhost:7175/api/User/register';
  private apiGetUrl = 'https://localhost:7175/api/User/all-users'; 
  private apiUpdateUrl='https://localhost:7175/api/User/update-status';
  private apiTechUrl = 'https://localhost:7175/api/User';

  constructor(private http: HttpClient) {}


  registerUser(user: User): Observable<any> {
    return this.http.post<User>(this.apiUrl, user);
  }

  // Method to fetch all users' usernames and emails
  getUsers(): Observable<any> {
    const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<any>(this.apiGetUrl,{ headers: headers });
  }
  updateUserStatus(userEmail: string, isActive: boolean): Observable<any> {
    const payload = { isActive };
    const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.put<any>(`${this.apiUpdateUrl}/${userEmail}`, payload,{ headers: headers });
  }
  getAllTechnicians(): Observable<any> {
    const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<any>(`${this.apiTechUrl}/all-tech`,{ headers: headers });
  }
  getAllUsers(): Observable<any> {
    const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<any>(`${this.apiTechUrl}/all-users`,{ headers: headers });
  }
  
}
