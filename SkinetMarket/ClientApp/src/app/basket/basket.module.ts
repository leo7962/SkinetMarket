import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BasketComponent} from './basket.component';
import {BasketRouting} from './basket-routing.routing';
import {SharedModule} from '../shared/shared.module';

@NgModule({
  declarations: [BasketComponent],
  imports: [CommonModule, BasketRouting, SharedModule],
})
export class BasketModule {
}
