import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { User,ILoginUser } from '../interfaces/common/user';
import { UserService } from '../services/common/user/user.service';
import { PersistanceService } from '../sharedservices/persitence.service';

@Injectable({
  providedIn: 'root'
})
export class AuthguardserviceService {

  private loggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }

  set isLoggedIn(status:any){
    this.loggedIn.next(status);
  }

  constructor(
    private router: Router,
    private userService:UserService,
    private persister: PersistanceService
  ) {}

  login(user: ILoginUser) {
    if (user.userId !== '' && user.password !== '' ) {      
      this.userService.getUserByUserId(user).subscribe((result) => {
        if (result) {
          if(result.status==1){
            this.persister.set('loggedinuser', result.loginUser);
            this.loggedIn.next(true);
            this.router.navigate(['/']);
          }
          else{
            console.log("Error");
          }
        }
        else {
        }
      }, error => {
        console.log(error);
      }, () => {
      });
    }
  }

  logout() {
    this.persister.set('loggedinuser', null);
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
  }
}
