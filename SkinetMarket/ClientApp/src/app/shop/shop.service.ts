import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/type';
import { map, delay } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  private myAppUrl = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.brandId !== 0) {
      params = params.append('brandId', shopParams.brandId.toString());
    }

    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageIndex', shopParams.pageSize.toString());

    return this.http
      .get<IPagination>(this.myAppUrl + 'api/products', {
        observe: 'response',
        params,
      })
      .pipe(
        // delay(1000),
        map((response) => {
          return response.body;
        })
      );
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.myAppUrl + 'api/products/brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.myAppUrl + 'api/products/types');
  }
}
