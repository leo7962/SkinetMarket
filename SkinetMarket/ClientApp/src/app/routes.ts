import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TestErrorComponent } from './core/test-error/test-error.component';

export const AppRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'test-error', component: TestErrorComponent },
  { path: 'shop', loadChildren: () =>  import('./shop/shop.module').then(mod => mod.ShopModule)},
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
