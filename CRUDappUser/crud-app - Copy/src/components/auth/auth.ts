import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../app/services/auth.service';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [CommonModule, FormsModule], // Required for ngModel and structural directives
  templateUrl: './auth.html',
  styleUrl: './auth.css',
})
export class AuthComponent {
  isLoginMode: boolean = true;
  errorMessage: string = '';
  successMessage: string = '';

  // Mock Captcha to satisfy backend requirement
  captchaSolved: boolean = false;

  loginObj = {
    email: '',
    password: '',
    captchaToken: ''
  };

  registerObj = {
    email: '',
    password: '',
    role: 'PolicyHolder' // Default role
  };

  constructor(private authService: AuthService, private router: Router) {}

  toggleMode() {
    this.isLoginMode = !this.isLoginMode;
    this.errorMessage = '';
    this.successMessage = '';
  }

  // Simulating a user solving a CAPTCHA
  solveCaptcha() {
    this.captchaSolved = true;
    this.loginObj.captchaToken = 'mock-captcha-token-12345'; // Backend just checks if not empty
  }

  onLogin() {
    if (!this.captchaSolved) {
      this.errorMessage = 'Please solve the CAPTCHA first.';
      return;
    }

    this.authService.login(this.loginObj).subscribe({
      next: (res) => {
        if (res.isSuccess) {
          this.authService.saveToken(res.token);
          // For now, redirect to your existing CRUD page upon login
          this.router.navigate(['/users']); 
        }
      },
      error: (err) => {
        this.errorMessage = err.error.message || 'Login failed. Check credentials.';
      }
    });
  }

  onRegister() {
    this.authService.register(this.registerObj).subscribe({
      next: (res) => {
        this.successMessage = 'Registration successful! Please log in.';
        this.isLoginMode = true; // Switch back to login form automatically
        this.errorMessage = '';
      },
      error: (err) => {
        // Handle Identity errors (e.g. password missing uppercase/special char)
        if (err.error && Array.isArray(err.error)) {
           this.errorMessage = err.error[0].description;
        } else {
           this.errorMessage = 'Registration failed. Passwords require an uppercase, lowercase, number, and special character.';
        }
      }
    });
  }
}