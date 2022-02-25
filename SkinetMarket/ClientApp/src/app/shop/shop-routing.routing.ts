import {RouterModule, Routes} from '@angular/router';
import {ShopComponent} from './shop.component';
import {ProductDetailsComponent} from './product-details/product-details.component';

const routes: Routes = [
  {path: '', component: ShopComponent},
  {
    path: ':id',
    component: ProductDetailsComponent,
    data: {breadcrumb: {alias: 'productDetails'}},
  },
];

export const ShopRoutingRoutes = RouterModule.forChild(routes);
