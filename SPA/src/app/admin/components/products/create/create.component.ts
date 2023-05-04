import { HttpErrorResponse } from '@angular/common/http';
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
    console.log(this.model);

    this.service.create(this.model).subscribe({
      next: (res) => {
        this.model = {
          name: "",
          price: 0,
          stock: 0
        }
        this.notiflix.success(MessageConstants.CREATED_OK_MSG)
        this.notiflix.hideLoading();
      },
      error: (e: HttpErrorResponse) => {
        let errorMessage = '';
        for (const [key, value] of Object.entries(e.error)) {
          for (const message of value as string[]) {
            errorMessage += `${message}\n`;
          }
        }

        console.log(errorMessage);
        this.notiflix.error(errorMessage);

        this.notiflix.hideLoading();
      }
    }).add(this.notiflix.hideLoading())
  }
}
