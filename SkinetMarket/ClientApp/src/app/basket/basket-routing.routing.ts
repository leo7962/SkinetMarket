import {RouterModule, Routes} from '@angular/router';
import {BasketComponent} from './basket.component';

const routes: Routes = [{path: '', component: BasketComponent}];

export const BasketRouting = RouterModule.forChild(routes);
