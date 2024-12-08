import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DeviceServiceService {

 
  private apiUrl = 'https://localhost:7175/api/Device';  // Adjust the API endpoint

constructor(private http: HttpClient) {}

addDevice(device: any, roomId: number): Observable<any> {
  // Adding roomId as a query parameter
  const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
  const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
  const url = `${this.apiUrl}`;
  return this.http.post<any>(`${url}`, device, {
    headers: headers,
    params: { roomId: roomId.toString() } ,
  });
}


getDevicesByRoomId(roomId: number): Observable<any[]> {
  const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
  const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
  const url = `${this.apiUrl}/GetDevicesByRoomId?roomId=${roomId}`;
  return this.http.get<any[]>(url, { headers: headers });
}
updateDeviceStatus(device: any): Observable<any> {
  const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
  const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
  return this.http.put<any>(`${this.apiUrl}/UpdateDeviceStatus/${device.deviceId}`, device,{ headers: headers });
}
updateDeviceSpeed(device: any): Observable<any> {
  const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
  const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
  return this.http.put<any>(`${this.apiUrl}/UpdateDeviceSpeed/${device.deviceId}`, device,{ headers: headers });
}

}
