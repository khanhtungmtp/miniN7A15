import { Injectable } from '@angular/core';
import { Product_Create, Product_List } from '../_models/product';
import { CommonService } from './common/common.service';

@Injectable({
  providedIn: "root"
})
export class ProductService {
  controller: string = "Product"
  constructor(
    private common: CommonService
  ) { }
  create(model: Product_Create) {
    return this.common.post<Product_Create>({ controller: this.controller, action: 'CreateProduct' }, model)
  }

  getAllProduct() {
    return this.common.get<Product_List[]>({ controller: this.controller, action: 'GetAllProduct' })
  }

}
