import { Routes, RouterModule } from "@angular/router";
import { CheckoutComponent } from "./checkout.component";

const routes: Routes = [
  { path: "", component: CheckoutComponent },
];

export const CheckoutRoutingRoutes = RouterModule.forChild(routes);
