import { Component, OnInit } from "@angular/core";


@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrl: './home.component.scss',
    standalone: false
})
export class HomeComponent implements OnInit {
  public userLoggedIn: boolean = false;
  public showRegisterForm: boolean = false
  public showLogin: boolean = false;
  public userLoggedOut: boolean = true;
  public showLogOutMenu: boolean = false;
  public isHomePage: boolean = true;

  public ngOnInit(): void {
    
  }

  public loginMenu(){
    this.showLogin = !this.showLogin;
    this.showRegisterForm = false;
  }

  public registerMenu(){
    this.showRegisterForm = !this.showRegisterForm;
    this.showLogin = false
  }

  public goToHomePage(){
    this.showLogin = false;
    this.showRegisterForm= false;
  }

  public logoutMenu(){
    this.userLoggedOut = true;
    this.isHomePage = true;
    this.showLogin = false;
    this.showRegisterForm= false;
    this.showLogOutMenu = false;
  }

  public LoginUser(){
    // Service Call;
    this.userLoggedIn = true;
    this.showLogOutMenu = true;
    this.showLogin = false;
    this.showRegisterForm = false;
  }
}
