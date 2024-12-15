import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
    selector: 'app-login-form',
    templateUrl: './login-form.component.html',
    styleUrl: './login-form.component.scss',
    standalone: false
})
export class LoginFormComponent implements OnInit{
    @Output() loginEvent = new EventEmitter<void>();

    ngOnInit(): void {
        
    }

    public proceedLogIn(){
        this.loginEvent.emit();
    }
}
