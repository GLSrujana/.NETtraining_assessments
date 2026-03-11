import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes } from '@angular/router';
import { Usercomp } from '../components/usercomp/usercomp';
import { AuthComponent } from '../components/auth/auth';

export const routes: Routes = [
  // Default route points to Login now
  { path: '', redirectTo: 'auth', pathMatch: 'full' },
  { path: 'auth', component: AuthComponent },
  
  // Your existing CRUD component
  { path: 'users', component: Usercomp } 
];