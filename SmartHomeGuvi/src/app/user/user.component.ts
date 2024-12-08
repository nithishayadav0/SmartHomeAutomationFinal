import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../Models/user';
import {UserService} from '../services/UserService.service'
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
@Component({
  selector: 'app-user',
  standalone: true,
  imports: [ ReactiveFormsModule,CommonModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})



export class UserComponent {
  userForm: FormGroup;
  isRegistered = false;
  constructor(private fb: FormBuilder, private userService: UserService,private router: Router) {
    this.userForm = this.fb.group({
      username: [
        '',
        [Validators.required, Validators.minLength(3), Validators.maxLength(50)],
      ],
      password: ['', [Validators.required, Validators.maxLength(255)]],
      role: [
        '',
        [
          Validators.required,
          Validators.pattern(/^(Homeowner|Administrator|Guest|DeviceTechnician)$/),
        ],
      ],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(100)]],
      isActive: [false, Validators.required],
    });
  }

  onSubmit(): void {
    if (this.userForm.valid) {
     
      const user: User = this.userForm.value;
      this.userService.registerUser(user).subscribe({
        next: (response) => {
          console.log('User registered successfully:', response);
          alert('User registered successfully!');
          this.userForm.reset();
          this.isRegistered = true;
          this.router.navigate(['/login']); 
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

}
