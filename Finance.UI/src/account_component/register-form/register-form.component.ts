import { Component, OnInit } from '@angular/core';
import { RegisterForm } from '../../models/register_form';
import { AccountService } from '../../services/account-service.service';

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
    public registerInputForm: RegisterForm = new RegisterForm();
    public emailPattern: string = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";

    constructor(private _accountService: AccountService){}

    ngOnInit(): void {
    }

    public proceedRegister(){
        this._accountService.registerUser(this.registerInputForm);
        this.registrationSuccess = true;
        if(this.registrationSuccess){
            this.renderLogin = true;
            this.showRegisterForm = false;
        }
    }
}
