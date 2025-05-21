import { NgModule } from '@angular/core';
import { HomeComponent } from '../home/home.component';
import { BrowserModule } from '@angular/platform-browser';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import { AppComponent } from './app.component';
import { MatMenuModule } from '@angular/material/menu';
import { AccountComponent } from '../account_component/account/account.component';
import { LoginFormComponent } from '../account_component/login-form/login-form.component';
import { RegisterFormComponent } from '../account_component/register-form/register-form.component';
import { LogoutFormComponent } from '../account_component/logout-form/logout-form.component';
import { CustomContentComponent } from '../content_component/custom-content/custom-content.component';
import { FormsModule } from '@angular/forms';
import { provideHttpClient } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AccountComponent,
    LoginFormComponent,
    RegisterFormComponent,
    LogoutFormComponent,
    CustomContentComponent
  ],
  imports: [
    BrowserModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatMenuModule,
    MatCardModule,
    MatFormFieldModule,
    FormsModule,
  ],
  providers: [provideHttpClient()],
  bootstrap: [HomeComponent]
})
export class AppModule { }
