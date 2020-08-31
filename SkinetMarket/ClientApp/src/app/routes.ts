import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShopComponent } from './shop/shop.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';

export const AppRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'shop', loadChildren: () =>  import('./shop/shop.module').then(mod => mod.ShopModule)},
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
