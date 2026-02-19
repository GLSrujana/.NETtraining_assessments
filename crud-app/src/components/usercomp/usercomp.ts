import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { User } from '../../app/interface/user';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-usercomp',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './usercomp.html',
  styleUrls: ['./usercomp.css']
})
export class Usercomp implements OnInit { // 1. Implemented OnInit

  users: User[] = [];

  user: User = {
    id: 0,
    name: '',
    email: '',
  };

  isEditMode: boolean = false;

  // 2. Define the .NET backend API URL (update the port if yours is different)
  private apiUrl = 'https://localhost:7297/api/Users';

  // 3. Inject HttpClient via the constructor
  constructor(private http: HttpClient) {}

  // 4. Fetch users automatically when the component loads
  ngOnInit(): void {
    this.loadUsers();
  }

  // READ (GET Request)
  loadUsers() {
    this.http.get<User[]>(this.apiUrl).subscribe({
      next: (data) => this.users = data,
      error: (err) => console.error('Failed to load users:', err)
    });
  }

  // CREATE & UPDATE (POST & PUT Requests)
  saveUser() {
    if (this.isEditMode) {
      // API call to Update
      this.http.put(`${this.apiUrl}/${this.user.id}`, this.user).subscribe({
        next: () => {
          // Update the local array to reflect changes in the UI
          const index = this.users.findIndex(u => u.id === this.user.id);
          if (index !== -1) {
            this.users[index] = { ...this.user };
          }
          this.isEditMode = false;
          this.resetForm();
        },
        error: (err) => console.error('Failed to update user:', err)
      });
    } else {
      // API call to Create (We don't generate the ID manually anymore, the DB does it)
      this.http.post<User>(this.apiUrl, this.user).subscribe({
        next: (createdUser) => {
          // Push the newly created user (which now has a real DB ID) to the UI
          this.users.push(createdUser);
          this.resetForm();
        },
        error: (err) => console.error('Failed to add user:', err)
      });
    }
  }

  // READ (Edit mode - UI only)
  editUser(selectedUser: User) {
    this.user = { ...selectedUser };
    this.isEditMode = true;
  }

  // DELETE (DELETE Request)
  deleteUser(id: number) {
    this.http.delete(`${this.apiUrl}/${id}`).subscribe({
      next: () => {
        // Remove from the local array to update the UI
        this.users = this.users.filter(u => u.id !== id);
      },
      error: (err) => console.error('Failed to delete user:', err)
    });
  }

  resetForm() {
    this.user = { id: 0, name: '', email: '' };
    this.isEditMode = false; // ensure edit mode resets too
  }
}