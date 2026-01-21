import { bootstrapApplication } from '@angular/platform-browser';
import { ServiceDemoComponent } from './components/service-demo/service-demo';

bootstrapApplication(ServiceDemoComponent)
  .catch(err => console.error(err));
