import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { RouterModule } from '@angular/router';
import { TestErrorComponent } from './test-error/test-error.component';

@NgModule({
  declarations: [NavMenuComponent, TestErrorComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [NavMenuComponent]
})
export class CoreModule { }
