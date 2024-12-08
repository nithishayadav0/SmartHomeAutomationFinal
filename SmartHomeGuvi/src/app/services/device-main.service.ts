import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DeviceMainService {

  private apiUrl = 'https://localhost:7175/api/DeviceMaintenance/create'
  private apiGetUrl='https://localhost:7175/api/DeviceMaintenance/maintenance'
  private apiGetAllUrl= 'https://localhost:7175/api/DeviceMaintenance/all-maintenance'
  private apiUpdateUrl ='https://localhost:7175/api/DeviceMaintenance';
  private apiGetDiagUrl='https://localhost:7175/api/DeviceMaintenance/run-diagnostics';

  
  constructor(private http: HttpClient) {}
  createMaintenanceRequest(deviceId: number,maintenanceRequest: Partial<any> ): Observable<any> {
    const token = localStorage.getItem('authToken'); 
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post<any>(`${this.apiUrl}?deviceId=${deviceId}`,maintenanceRequest ,{ headers: headers });
  }

   

  getMaintenanceRequests(): Observable<any> {
    const token = localStorage.getItem('authToken'); 

    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    return this.http.get<any>(this.apiGetUrl, { headers:headers });
  }
  getAllMaintenanceRequests(): Observable<any[]> {
    const token = localStorage.getItem('authToken'); 

    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<any[]>(this.apiGetAllUrl,{ headers:headers });
  }
  
  updateStatus(maintenanceId: number, status: string): Observable<any> {
   
    const url = `${this.apiUpdateUrl}/update-status/${maintenanceId}`;
   
  
    return this.http.put<any>(url, {status}).pipe(
      catchError((error) => {
        console.error('Error updating status:', error);
        if (error.error?.errors) {
          console.error('Validation Errors:', error.error.errors);
        }
        return throwError(error);  
      })
    );
  }
  GetDiagnostics(deviceId: number): Observable<any[]> {
    const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<any[]>(`${this.apiGetDiagUrl}/${deviceId}`,{ headers: headers });
  }
  updateDiagnostics(deviceId: number, diagnosticsReport: any): Observable<any> {
    const url = `${this.apiGetDiagUrl}/${deviceId}`;
    const token = localStorage.getItem('authToken');
    const headers = new HttpHeaders()
    .set('Authorization', `Bearer ${token}`)
    .set('Content-Type', 'application/json');

    return this.http.post(url, diagnosticsReport, { headers });
  }
}
