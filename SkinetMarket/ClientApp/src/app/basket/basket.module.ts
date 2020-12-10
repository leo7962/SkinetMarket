import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './basket.component';
import { BasketRouting } from './basket-routing.routing';


@NgModule({
  declarations: [BasketComponent],
  imports: [
    CommonModule,
    BasketRouting
  ]
})
export class BasketModule { }
