import { CommonService } from './../../../_core/_services/common/common.service';
import { Component } from '@angular/core';
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
  }
}
