import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CheckoutComponent} from './checkout.component';
import {CheckoutRoutingRoutes} from './checkout-routing.routing';


@NgModule({
  declarations: [CheckoutComponent],
  imports: [
    CommonModule,
    CheckoutRoutingRoutes
  ]
})
export class CheckoutModule {
}
