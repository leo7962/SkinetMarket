import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AccountRouting } from './account-routing.routing';

@NgModule({
  declarations: [LoginComponent, RegisterComponent],
  imports: [CommonModule, AccountRouting],
})
export class AccountModule {}
