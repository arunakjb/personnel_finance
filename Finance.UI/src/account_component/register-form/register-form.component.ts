import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-register-form',
    templateUrl: './register-form.component.html',
    styleUrl: './register-form.component.scss',
    standalone: false
})
export class RegisterFormComponent implements OnInit{
    public showRegisterForm: boolean = true;
    public registrationSuccess: boolean = false
    public renderLogin: boolean = false;
    ngOnInit(): void {
        
    }
    public proceedRegister(){
        this.registrationSuccess = true;
        if(this.registrationSuccess){
            this.renderLogin = true;
            this.showRegisterForm = false;
        }
    }
}
