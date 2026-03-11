import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // IMPORTANT: Make sure this matches your .NET port!
  private apiUrl = 'https://localhost:7297/api/Auth';

  constructor(private http: HttpClient) {}

  // 1. Register a new user
  register(userData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, userData);
  }

  // 2. Log in
  login(credentials: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, credentials);
  }

  // 3. Save the token to browser storage
  saveToken(token: string): void {
    localStorage.setItem('jwtToken', token);
  }

  // 4. Get the token from browser storage
  getToken(): string | null {
    return localStorage.getItem('jwtToken');
  }

  // 5. Check if the user is currently logged in
  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  // 6. Log out (delete the token)
  logout(): void {
    localStorage.removeItem('jwtToken');
  }

  // 7. Decode the JWT to get the User's Role and Name
  getUserRole(): string | null {
    const token = this.getToken();
    if (!token) return null;

    try {
      // JWTs are split into 3 parts by periods. The middle part is the data payload.
      const payload = token.split('.')[1];
      const decodedJson = atob(payload); // Decodes Base64
      const decodedToken = JSON.parse(decodedJson);
      
      // Microsoft Identity stores the role under this massive dictionary key
      return decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || null;
    } catch (e) {
      console.error('Error decoding token', e);
      return null;
    }
  }
}