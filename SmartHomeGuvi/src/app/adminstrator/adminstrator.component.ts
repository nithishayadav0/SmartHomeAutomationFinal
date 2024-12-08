import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router'
import { UsageServiceService } from '../services/usage-service.service';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserService } from '../services/UserService.service';
import { ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-adminstrator',
  standalone: true,
  imports: [FormsModule, CommonModule,ReactiveFormsModule ],
  templateUrl: './adminstrator.component.html',
  styleUrl: './adminstrator.component.css'
})
export class AdminstratorComponent implements OnInit{
  constructor(private fb: FormBuilder,private router:Router,private usageService:UsageServiceService,private route: ActivatedRoute,private userService:UserService){}
  technicians: any[] = [];
  isModalOpen: boolean = false;
  userEmail:string='';
  errorMessage:string='';
  userRole: string = '';
  userList:any[]=[];
  users: any[] = [];
  
  userForm!: FormGroup;
  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.userRole = params['role']; 
      this.getTechnicians();
      this.fetchUsers();
      this.initializeForm();  
      this.getUsers();
    });
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
  getTechnicians(): void {
    this.userService.getAllTechnicians().subscribe(
      (data) => {
        this.technicians = data;
        console.log('Technicians:', this.technicians);
      },
      (error) => {
        console.error('Error fetching technicians:', error);
      }
    );
  }
  // Open the modal
  openModal(): void {
    this.isModalOpen = true;
  }

  // Close the modal
  closeModal(): void {
    this.isModalOpen = false;
  }

  navigateToUserList(){
    this.router.navigate(['/UserList'])
  }
  navigateToGlobalAutomations(){
    this.router.navigate(['/global-automations'])
  }
  submitUserEmail(): void {
    if (this.userEmail) {
      this.usageService.updateUserEmail(this.userEmail);  
      
      this.closeModal();  
      this.router.navigate(['/usage-report'])
    } else {
      this.errorMessage = 'Username cannot be empty!';
    }
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
    updateUser(){

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
    deactivateTechnician(userEmail: string): void {
      const userIndex = this.technicians.findIndex((user) => user.email === userEmail);
      if (userIndex !== -1) {
        const user = this.technicians[userIndex];
        const newStatus = !user.isActive; // Toggle active status
      
        this.userService.updateUserStatus(userEmail, newStatus).subscribe((updatedUser) => {
          if (updatedUser) {
            this.technicians[userIndex].isActive = updatedUser.isActive;
            console.log(`User ${updatedUser.username} is now ${updatedUser.isActive ? 'active' : 'inactive'}.`);
          }
        });
      }
    }
    getUsers(): void {
      this.userService.getAllUsers().subscribe(
        (data) => {
          this.users = data; 
          console.log('Users:', this.users);
        },
        (error) => {
          console.error('Error fetching users:', error); // Log error if any
        }
      );
    }
    
}
