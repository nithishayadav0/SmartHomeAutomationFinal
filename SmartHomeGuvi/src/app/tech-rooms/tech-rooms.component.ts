import { Component, OnInit } from '@angular/core';
import { RoomServiceService } from '../services/room-service.service';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-tech-rooms',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './tech-rooms.component.html',
  styleUrl: './tech-rooms.component.css'
})
export class TechRoomsComponent implements OnInit {
  constructor(private roomService :RoomServiceService,private router:Router,    private activatedRoute: ActivatedRoute){}
  
  rooms: any[] = [];
  username: string = '';  // Assume this will be set dynamically (from auth or a service)
  email: string = ''; // Assume this will be set dynamically (from auth or a service)

  

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(params => {
      this.username = params['username'];
      this.email = params['useremail'];
  
    // Fetch rooms by username and email
    this.roomService.getRoomsByUsernameAndEmail(this.username, this.email).subscribe(
      (rooms: any[]) => {
        this.rooms = rooms;
      },
      (error) => {
        console.error('Error fetching rooms', error);
    })
  })
  }
    navigateToAddDevice(selectedRoomId: number) {
      this.router.navigate(['/add-device'],{ queryParams: { roomId: selectedRoomId } });
    }
 
    
    getBackgroundImage(roomName: string): string {
      if (roomName.toLowerCase() === 'bedroom') {
        return 'url(https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQipFiK07AHxC1VW3P3uF-ZnqWs3v3qsayWfQ&s)';
      } else if (roomName.toLowerCase() === 'kitchen') {
        return 'url(https://images.woodenstreet.de/image/data/modular%20kitchen/22.jpg)';
      } else if (roomName.toLowerCase() === 'living room') {
        return 'url(https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBmqNgjci6KnLjSU9WFIKi0Y8NiE6XOEVPMg&s)';
      }
      else if (roomName.toLowerCase() === 'washroom'){
        return 'url(https://img.freepik.com/premium-photo/latest-modern-design-washroom_124907-173.jpg)';
      }
      else {
        return 'url(https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcRYAjTYUMx_8bcqHO6vJF85xFGkeBUHk0Ln2Ix8-SWKXx9ypck1iQQNkygY28U9j5k8g63zx6giH88-wgQoew4RJ0ql_SaSRgDyqBqBcQY)';
      }
    }
}