import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsageServiceService {
  private apiUrl = 'https://localhost:7175/api/EnergyUsage/usage-report';
  private apiMonthlyUrl = 'https://localhost:7175/api/EnergyUsage/GetMonthlyEnergyReport';
  constructor(private http: HttpClient) { }
  private userEmailSource = new BehaviorSubject<string>('');  // Default value is empty string
  userEmail$ = this.userEmailSource.asObservable();  // Observable to subscribe to the username changes
  getReport(): Observable<any> {
    
    const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<any>(this.apiUrl, { headers: headers });    
  }
  updateUserEmail(userEmail: string): void {
    this.userEmailSource.next(userEmail);
  }


  getMonthlyEnergyReport(userEmail: string): Observable<any[]> {
       
    const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const params = new HttpParams().set('userEmail', userEmail);
    return this.http.get<any[]>(this.apiMonthlyUrl, { headers, params });
  }
}
