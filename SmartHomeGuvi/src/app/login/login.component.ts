import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginServiceService } from '../services/login-service.service';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthServiceService } from '../services/auth-service.service';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private loginService: LoginServiceService,private router: Router,private authService:AuthServiceService) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required,  Validators.maxLength(100)]],
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      this.loginService.login(this.loginForm.value).subscribe({
        next: (response) => {
          console.log('Login successful:', response);
          alert('Login successful!');
          const token = response.token;
          const userRole = response.role; 
          const userName=response.username;
          const email=response.email;
          const password=response.password;
        if (token) {
          localStorage.setItem('authToken', token);
          localStorage.setItem('userRole', userRole);
          localStorage.setItem('userName', userName);
          this.authService.setUserData(response);
          console.log('authToken and userRole stored successfully');
          if (userRole === 'Homeowner' || userRole=='Guest') {
            this.router.navigate(['/dashboard']); 
          } else if (userRole === 'DeviceTechnician') {
            this.router.navigate(['/tech-home']); 
          } 
          else if(userRole === 'Administrator'){
            this.router.navigate(['/admin-home']); 
          }
          else {
            console.error('Unknown user role:', userRole);
            alert('Unknown role. Contact support.');
          }
        }
        },
        error: (err) => {
          console.error('Login failed:', err);
          alert('Login failed. Please check your credentials.');
        },
      });
    } else {
      console.error('Form is invalid');
    }
  }
}


