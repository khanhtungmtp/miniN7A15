import { CommonService } from './../../../_core/_services/common/common.service';
import { Component } from '@angular/core';
import { MessageConstants } from 'src/app/_core/_constants/message.enum';
import { NotiflixService } from 'src/app/_core/_services/common/notiflix.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent {
  /**
   *
   */
  constructor(private notiflix: NotiflixService, private commonService: CommonService) {
  }
  ngOnInit(): void {
    this.getProduct();
  }
  getProduct() {
    this.notiflix.showLoading();
    this.commonService.get({ controller: 'Product/GetAllProduct' }).subscribe({
      next: (res) => {
        console.log(res);
        this.notiflix.hideLoading();
      },
      error: () => {
        this.notiflix.hideLoading();
        this.notiflix.error(MessageConstants.SYSTEM_ERROR_MSG);
      }
    })
  }

  CreateProduct() {

  }
}
