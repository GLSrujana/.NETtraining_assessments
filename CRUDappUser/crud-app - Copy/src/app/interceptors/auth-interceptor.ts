import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  let token = null;

  // SAFE CHECK: This fixes the 401 error in Angular 17+
  if (typeof window !== 'undefined' && window.localStorage) {
    token = localStorage.getItem('jwtToken');
  }

  // Debugging: This will print in your console so you know it's working!
  console.log("Interceptor is sending token:", token ? "YES" : "NO");

  if (token) {
    const clonedReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
    return next(clonedReq);
  }

  return next(req);
};