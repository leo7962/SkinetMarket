import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  private myAppUrl = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getProducts() {
    return this.http.get<IPagination>(this.myAppUrl + 'api/products?pageSize=50');
  }
}
