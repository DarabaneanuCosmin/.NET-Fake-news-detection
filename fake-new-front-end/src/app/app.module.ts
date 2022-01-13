import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule, routingComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { DataSetInputComponent } from './components/data-set-input/data-set-input.component';
import { LastInputsUserComponent } from './components/last-inputs-user/last-inputs-user.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { MainPageComponent } from './final-pages/main-page/main-page.component';
import { UserPageComponent } from './final-pages/user-page/user-page.component';
import { FooterComponent } from './components/footer/footer.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from './components/modal/modal.component';
import { HttpClientModule } from  '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { IncorrectInputComponent } from './components/incorrect-input/incorrect-input.component';
import { AuthGuard } from './services/auth-guard';
import { SignUpErrorComponent } from './components/sign-up-error/sign-up-error.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    DataSetInputComponent,
    LastInputsUserComponent,
    LogInComponent,
    SignInComponent,
    MainPageComponent,
    UserPageComponent,
    FooterComponent,
    routingComponents,
    ModalComponent,
    IncorrectInputComponent,
    SignUpErrorComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }