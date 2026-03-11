import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withInterceptors } from '@angular/common/http';

import { routes } from './app.routes';
import { authInterceptor } from './interceptors/auth-interceptor'; // Import the interceptor

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    // Register the interceptor here:
    provideHttpClient(withInterceptors([authInterceptor])) 
  ]
};