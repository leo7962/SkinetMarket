import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {CounterComponent} from './counter/counter.component';
import {FetchDataComponent} from './fetch-data/fetch-data.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {CoreModule} from './core/core.module';
import {HomeModule} from './home/home.module';
import {AppRoutes} from './routes';
import {ErrorInterceptor} from './core/interceptors/error.interceptor';
import {NgxSpinnerModule} from 'ngx-spinner';
import {LoadingInterceptor} from './core/interceptors/loading.interceptor';

@NgModule({
  declarations: [AppComponent, CounterComponent, FetchDataComponent],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    CoreModule,
    HomeModule,
    RouterModule.forRoot(AppRoutes, {relativeLinkResolution: 'legacy'}),
    BrowserAnimationsModule,
    NgxSpinnerModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoadingInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
}
