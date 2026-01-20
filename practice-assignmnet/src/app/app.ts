import { Component } from '@angular/core';

import { Navigation } from '../components/navbar/navbar';
import { Description } from '../components/description/description';
import { WelcomeBanner } from '../components/welcome-banner/welcome-banner';
import { InsuranceProfiles } from '../components/insurance-profiles/insurance-profiles';
import { Header } from '../components/header/header';
import { Footer } from '../components/footer/footer';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    Header,
    Navigation,
    Description,
    WelcomeBanner,
    InsuranceProfiles,
    Footer
  ],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {}
