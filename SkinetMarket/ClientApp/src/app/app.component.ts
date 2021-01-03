import { Component, OnInit, Inject } from '@angular/core';
import { BasketService } from './basket/basket.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  title = 'SkinetMarket';
  private myAppUrl = '';

  constructor(private basketService: BasketService, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  ngOnInit(): void {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) {
      this.basketService.getBasket(basketId).subscribe(() => {
        console.log('Initialised basket');
      }, error => {
        console.log(error);
      });
    }
  }
}
