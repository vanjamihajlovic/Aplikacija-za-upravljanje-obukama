import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../shared/services/auth.service';

@Injectable({ providedIn: 'root' })
export class RoleGuard implements CanActivate {
    constructor(private authService: AuthService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const requiredRole = route.data['roles'] as Array<string>;
        const userRole = this.authService.getUserRole();
        if (userRole && !requiredRole.includes(userRole))
            return false;
        return true;
    }

}