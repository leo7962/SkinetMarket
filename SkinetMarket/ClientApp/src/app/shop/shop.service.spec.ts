/* tslint:disable:no-unused-variable */

import {inject, TestBed} from '@angular/core/testing';
import {ShopService} from './shop.service';

describe('Service: Shop', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ShopService]
    });
  });

  it('should ...', inject([ShopService], (service: ShopService) => {
    expect(service).toBeTruthy();
  }));
});
