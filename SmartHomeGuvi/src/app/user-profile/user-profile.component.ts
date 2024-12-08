import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/UserService.service';
import { CommonModule } from '@angular/common';
import { AuthServiceService } from '../services/auth-service.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-user-profile',
  standalone: true,
  imports: [ CommonModule,ReactiveFormsModule],
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent implements OnInit{
  
  user: any = null; // Array to store user data

  constructor(
    private authService: AuthServiceService,
    private userService: UserService,  // Service to update user
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    console.log(this.user);
    this.user = this.authService.getUserData();
    this.initForm()
   
  }
  updateForm!: FormGroup;
  isEditMode = false; // To toggle form visibility

 


  // Initialize the form with existing user data
  initForm(): void {
    this.updateForm = this.fb.group({
      username: [this.user.username, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      email: [this.user.email, [Validators.required, Validators.email, Validators.maxLength(100)]],
      password: [this.user.password, [Validators.required, Validators.maxLength(255)]],
      role:[this.user.role, [Validators.required, Validators.maxLength(255)]],
      isActive:[this.user.isActive, [Validators.required]]
    });
  }

  // Function to toggle between and edit 
  toggleEdit(): void {
    this.isEditMode = !this.isEditMode;
  }

  // Function to submit the form data
  updateUser(): void {
    if (this.updateForm.invalid) {
      return; 
    }

    const updatedUser = this.updateForm.value; 
    this.authService.updateUser(this.user.UserId, updatedUser).subscribe(
      (response) => {
        console.log('User updated successfully', response);
        this.user = { ...this.user, ...updatedUser }; 
        this.isEditMode = false; 
      },
      (error) => {
        console.error('Error updating user:', error);
      }
    );
  }

}
