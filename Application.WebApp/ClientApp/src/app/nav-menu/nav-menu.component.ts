import { Component } from '@angular/core';

import { AuthguardserviceService } from '../auth/authguardservice.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  constructor(
    private authService: AuthguardserviceService){

    }

    onlogout(){
      this.authService.logout();
    }
}
