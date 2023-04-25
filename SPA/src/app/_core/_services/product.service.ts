import { Injectable } from '@angular/core';
import { Product_Create } from '../_models/product';
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
    return this.common.post({ controller: this.controller }, model)
  }

}
