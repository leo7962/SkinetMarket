import {Component, OnInit, Inject} from '@angular/core';
import {AccountService} from './account/account.service';
import {BasketService} from './basket/basket.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  title = 'SkinetMarket';
  private myAppUrl = '';

  constructor(private basketService: BasketService, @Inject('BASE_URL') baseUrl: string, private accountService: AccountService) {
    this.myAppUrl = baseUrl;
  }

  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUser();
  }

  loadCurrentUser() {
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe(() => {
      console.log('loaded user');
    }, error => {
      console.log(error);
    });
  }

  loadBasket() {
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
