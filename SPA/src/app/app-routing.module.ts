import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { LayoutComponent } from './admin/layout/layout.component';
import { HomeComponent } from './ui/components/home/home.component';

const routes: Routes = [
  {
    path: 'admin',
    component: LayoutComponent,
    children: [
      { path: '', component: DashboardComponent }
      ,
      {
        path: 'customers',
        loadChildren: () => import('./admin/components/customer/customer.module').then(m => m.CustomerModule)
      },
      {
        path: 'products',
        loadChildren: () => import('./admin/components/products/products.module').then(m => m.ProductsModule)
      },
      {
        path: 'order',
        loadChildren: () => import('./admin/components/order/order.module').then(m => m.OrderModule)
      }
    ]
  },
  { path: '', component: HomeComponent },
  {
    path: 'basket',
    loadChildren: () => import('./ui/components/baskets/baskets.module').then(m => m.BasketsModule)
  },
  {
    path: 'products',
    loadChildren: () => import('./ui/components/products/products.module').then(m => m.ProductsModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
