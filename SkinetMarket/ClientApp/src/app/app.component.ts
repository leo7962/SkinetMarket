import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from './models/product';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  title = 'SkinetMarket';
  private myAppUrl = '';
  products: IProduct[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  ngOnInit() {
    this.http.get(this.myAppUrl + 'api/products').subscribe(
      (Response: IPagination) => {
        this.products = Response.data;
      },
      (error) => console.error(error)
    );
  }
}
