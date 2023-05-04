import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Product_List } from 'src/app/_core/_models/product';
import { CommonService } from 'src/app/_core/_services/common/common.service';
import { ProductService } from 'src/app/_core/_services/product.service';
export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}
const ELEMENT_DATA: Product_List[] = [
  { name: 't', stock: 2, price: 4.0026, createdDate: new Date(), updatedDate: new Date() },
  { name: 't', stock: 2, price: 4.0026, createdDate: new Date(), updatedDate: new Date() },
  { name: 't', stock: 2, price: 4.0026, createdDate: new Date(), updatedDate: new Date() },
  { name: 't', stock: 2, price: 4.0026, createdDate: new Date(), updatedDate: new Date() },
  { name: 't', stock: 2, price: 4.0026, createdDate: new Date(), updatedDate: new Date() },
  { name: 't', stock: 2, price: 4.0026, createdDate: new Date(), updatedDate: new Date() },
  { name: 't', stock: 2, price: 4.0026, createdDate: new Date(), updatedDate: new Date() },
];
@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})

export class MainComponent {
  displayedColumns: string[] = ['No', 'Name', 'Stock', 'Price', 'Create Date', 'Update Date'];
  dataSource: MatTableDataSource<Product_List> = new MatTableDataSource<Product_List>([]);
  @ViewChild(MatPaginator) paginator?: MatPaginator;

  /**
   *
   */
  constructor(private service: ProductService,
    private common: CommonService) { }
  ngOnInit(): void {
    this.getAllProduct()

  }
  getAllProduct() {
    this.common.notiflix.showLoading()
    this.service.getAllProduct().subscribe({
      next: (res: Product_List[]) => {
        this.dataSource = new MatTableDataSource<Product_List>(res)
        if (this.paginator)
          this.dataSource.paginator = this.paginator
        this.common.notiflix.hideLoading()
      },
      error: () => {
        this.common.notiflix.hideLoading()
      }
    }).add(this.common.notiflix.hideLoading())
  }
}
