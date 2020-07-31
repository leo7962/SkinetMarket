import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/type';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  private myAppUrl = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getProducts() {
    return this.http.get<IPagination>(
      this.myAppUrl + 'api/products?pageSize=50'
    );
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.myAppUrl + 'api/products/brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.myAppUrl + 'api/products/types');
  }
}
