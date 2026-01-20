import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-insurance-profiles',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './insurance-profiles.html',
  styleUrls: ['./insurance-profiles.css']
})
export class InsuranceProfiles {
  profiles = [
    { name: 'Auto', img: 'https://cdn-icons-png.flaticon.com/512/744/744465.png' },
    { name: 'Home', img: 'https://cdn-icons-png.flaticon.com/512/1946/1946436.png' },
    { name: 'Business', img: 'https://cdn-icons-png.flaticon.com/512/3135/3135715.png' },
    { name: 'Life', img: 'https://cdn-icons-png.flaticon.com/512/2966/2966486.png' }
  ];
}
