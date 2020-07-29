import { Component, OnInit, Inject } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  title = 'SkinetMarket';
  private myAppUrl = '';

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  ngOnInit() {}
}
