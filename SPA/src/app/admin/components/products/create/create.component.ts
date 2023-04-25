import { MessageConstants } from './../../../../_core/_constants/message.enum';
import { Component } from '@angular/core';
import { Product_Create } from 'src/app/_core/_models/product';
import { InjectBase } from 'src/app/_core/_services/common/injectBase';
import { ProductService } from 'src/app/_core/_services/product.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent extends InjectBase {
  model: Product_Create = <Product_Create>{
    name: "",
    price: 0,
    stock: 0
  }
  ngOnInit(): void {
  }
  /**
   *
   */
  constructor(
    private service: ProductService
  ) {
    super();
  }
  createProduct() {
    this.notiflix.showLoading();
    this.service.create(this.model).subscribe({
      next: (res) => {
        this.model = res
        this.notiflix.success(MessageConstants.CREATED_OK_MSG)
        this.notiflix.hideLoading();
      },
      error: () => {
        this.notiflix.hideLoading();
        this.notiflix.error(MessageConstants.UN_KNOWN_ERROR)
      }
    })
  }
}
