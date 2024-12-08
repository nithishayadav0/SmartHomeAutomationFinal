import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';


@Injectable({
  providedIn: 'root'
})
export class RoomServiceService{

  private apiUrl = 'https://localhost:7175/api/Room/user-rooms';
  
private apiGetByEmailUrl = 'https://localhost:7175/api/Room/roomsbyEmail';
private roomsSubject = new BehaviorSubject<any[]>([]);

  constructor(private http: HttpClient,@Inject(PLATFORM_ID) private platformId: Object) {}

  getRooms(): Observable<any> {
 
    const token = localStorage.getItem('authToken');  // Ensure token is stored in localStorage
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<any>(this.apiUrl, { headers: headers });    
}

addRoom(room: { name: string; floor: number; zoneId: number; roomType: string }): Observable<any> {
  const apiUrl = 'https://localhost:7175/api/Room';
  const token = localStorage.getItem('authToken');  
  const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

  // Send the POST request with the token in the headers
  return this.http.post<any>(apiUrl, room, { headers: headers });
}

  rooms$ = this.roomsSubject.asObservable();

  setRooms(rooms: any[]) {
    this.roomsSubject.next(rooms);
  }



// Method to get rooms by username and user email
getRoomsByUsernameAndEmail(username: string, useremail: string): Observable<any> {
  const url = `${this.apiGetByEmailUrl}?username=${username}&useremail=${useremail}`;
  const token = localStorage.getItem('auth_token'); // assuming you store token in local storage

  const headers = new HttpHeaders({
    'Authorization': `Bearer ${token}`
  });

  return this.http.get<any>(url, { headers:headers });
}
  
}
