import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/UserService.service';
import { CommonModule } from '@angular/common';
import {Router} from '@angular/router'
import { FormGroup,FormBuilder, FormsModule, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [ CommonModule,FormsModule,ReactiveFormsModule],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent implements OnInit{
  userList:any[]=[];
  errorMessage:string='';
  userForm!: FormGroup;
  constructor (private fb: FormBuilder,private userService:UserService,private router:Router,private http:HttpClient){}
  ngOnInit(): void {
    this.fetchUsers();
    this.initializeForm();  
  }
  

  initializeForm(): void {
    this.userForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      role: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      isActive: [false],
    });
  }
  fetchUsers(): void {
    this.userService.getUsers().subscribe(
      (data) => {
        this.userList = data; 
        console.log(this.userList) ;// Store the fetched user data
      },
      (error) => {
        this.errorMessage = 'Failed to load user data. Please try again later.';
        console.error('Error fetching users:', error);
      }
    )}
    onSubmit(): void {
      if (this.userForm.valid) {
        const user: any = this.userForm.value;
        this.userService.registerUser(user).subscribe({
          next: (response) => {
            console.log('User registered successfully:', response);
            alert('User registered successfully!');
            this.userForm.reset();
            this.closeLightbox();
            this.fetchUsers();
            
          },
          error: (err) => {
            console.log('Error registering user:', err);
            alert('Failed to registerrr user. Please try again.');
            
          },
        });
      } else {
        console.error('Form is invalid');
      }
    }
    navigateToRooms(username: string, useremail: string): void {
      // Navigating to /user-rooms with query parameters
      this.router.navigate(['/tech-rooms'], { queryParams: { username, useremail } });
    }
   
    isLightboxOpen = false;

    navigateToUser(): void {
      this.isLightboxOpen = true;
    }
  
    closeLightbox(): void {
      this.isLightboxOpen = false;
    }
    
    deactivateUser(userEmail: string): void {
      const userIndex = this.userList.findIndex((user) => user.email === userEmail);
      if (userIndex !== -1) {
        const user = this.userList[userIndex];
        const newStatus = !user.isActive; // Toggle active status
    
        this.userService.updateUserStatus(userEmail, newStatus).subscribe((updatedUser) => {
          if (updatedUser) {
            this.userList[userIndex].isActive = updatedUser.isActive;
            console.log(`User ${updatedUser.username} is now ${updatedUser.isActive ? 'active' : 'inactive'}.`);
          }
        });
      }
    }
    
}

