import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterForm } from '../models/register_form';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private httpClient: HttpClient) { 
  }

  public registerUser(registerInput: RegisterForm){
    this.httpClient.post(' https://localhost:7085/Api/Account/Register', registerInput).subscribe(x =>{
      console.log(x);
    })
  }

  public loginUser(){

  }
}
