import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AutomationServiceService {

  private apiUrl = 'https://localhost:7175/api/Automation'; 
  private apiGlobalUrl = 'https://localhost:7175/api/GlobalAutomation';

  constructor(private http: HttpClient) {}

  // Method to get automations by user

  getAutomations(): Observable<any> {
 
    const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<any>(this.apiUrl, { headers: headers });    
}
 

  createAutomation(automationData: any): Observable<any> {
    const token = localStorage.getItem('authToken'); 
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post<any>(`${this.apiUrl}?deviceId=${automationData.deviceId}`, automationData,{ headers: headers });
  }

  
  deleteAutomation(automationId: number): Observable<any> {
    const token = localStorage.getItem('authToken'); 
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.delete(`${this.apiUrl}/${automationId}`,{ headers: headers });
  }
 
    getAllAutomations(): Observable<any[]> {
      const token = localStorage.getItem('authToken'); 
      const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
      return this.http.get<any[]>(`${this.apiGlobalUrl}`,{ headers: headers });
    }
  
    addAutomation(automation: any): Observable<any> {
      const token = localStorage.getItem('authToken'); 
      const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
      return this.http.post<any>(`${this.apiGlobalUrl}`, automation,{ headers: headers });
    }
    
}