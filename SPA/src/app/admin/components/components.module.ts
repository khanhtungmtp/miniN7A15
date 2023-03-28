import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComponentsComponent } from './components.component';
import { ProductsModule } from './products/products.module';
import { OrderModule } from './order/order.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { CustomerModule } from './customer/customer.module';


@NgModule({
  declarations: [
    ComponentsComponent
  ],
  imports: [
    CommonModule,
    CustomerModule,
    DashboardModule,
    OrderModule,
    ProductsModule
  ]
})
export class ComponentsModule { }
