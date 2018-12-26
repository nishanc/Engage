import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Injectable()

export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router, private alertify: AlertifyService) {

  }
  canActivate(): Observable<boolean> | Promise<boolean> | boolean {
    if (this.authService.loggedIn()) {
      return true;
    }

    this.alertify.error('You need to be logged in to access this!');
    this.router.navigate(['/home']);
    return false;
  }
}
