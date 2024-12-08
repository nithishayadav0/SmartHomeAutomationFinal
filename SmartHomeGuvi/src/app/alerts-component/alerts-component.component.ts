import { Component, OnInit } from '@angular/core';
import * as signalR from '@microsoft/signalr';
@Component({
  selector: 'app-alerts-component',
  standalone: true,
  imports: [],
  templateUrl: './alerts-component.component.html',
  styleUrl: './alerts-component.component.css'
})
export class AlertsComponentComponent implements OnInit {
  private hubConnection: signalR.HubConnection | null = null;

  constructor() {}

  ngOnInit() {
    // Initialize SignalR connection
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:7175/alertHub')  // Replace with your backend URL
      .build();

    // Start the connection
    this.hubConnection
      .start()
      .then(() => console.log('SignalR Connected'))
      .catch(err => console.log('Error connecting to SignalR', err));

    // Listen for alerts from the backend
    this.hubConnection.on('ReceiveAlert', (message: string) => {
      alert(message);  // Display the alert message in the browser
      alert("The ac is on for too long")
      console.log("connected")
    });
  }
}
