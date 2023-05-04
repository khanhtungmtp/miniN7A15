export interface Product_Create {
  name: string;
  stock: number;
  price: number;
}
export interface Product_List {
  name: string;
  stock: number;
  price: number;
  createdDate: Date;
  updatedDate: Date;
}
