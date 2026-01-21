import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Usercomp } from "../components/usercomp/usercomp";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, Usercomp],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {}
