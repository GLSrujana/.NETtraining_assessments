import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../../app/interface/user';
import { AuthService } from '../../app/services/auth.service';

@Component({
  selector: 'app-usercomp',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './usercomp.html',
  styleUrls: ['./usercomp.css']
})
export class Usercomp implements OnInit {

  users: User[] = [];
  user: User = { id: 0, name: '', email: '' };
  isEditMode: boolean = false;
  
  userRole: string | null = ''; // Stores current role
  private apiUrl = 'https://localhost:7297/api/users'; // Verify your port!

  constructor(
    private http: HttpClient, 
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/auth']);
      return;
    }
    this.userRole = this.authService.getUserRole();
    this.loadUsers();
  }

  loadUsers() {
    this.http.get<User[]>(this.apiUrl).subscribe({
      next: (data) => this.users = data,
      error: (err) => console.error('Failed to load', err)
    });
  }

  saveUser() {
    if (this.isEditMode) {
      this.http.put(`${this.apiUrl}/${this.user.id}`, this.user).subscribe({
        next: () => {
          const index = this.users.findIndex(u => u.id === this.user.id);
          if (index !== -1) this.users[index] = { ...this.user };
          this.isEditMode = false;
          this.resetForm();
        }
      });
    } else {
      this.http.post<User>(this.apiUrl, this.user).subscribe({
        next: (createdUser) => {
          this.users.push(createdUser);
          this.resetForm();
        }
      });
    }
  }

  editUser(selectedUser: User) {
    this.user = { ...selectedUser };
    this.isEditMode = true;
  }

  deleteUser(id: number) {
    this.http.delete(`${this.apiUrl}/${id}`).subscribe({
      next: () => this.users = this.users.filter(u => u.id !== id)
    });
  }

  resetForm() {
    this.user = { id: 0, name: '', email: '' };
    this.isEditMode = false;
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/auth']);
  }
}