import {v4 as uuidv4} from 'uuid';

export interface IBasket {
  id: string;
  items: IBasketItem[];
}
export interface IBasketItem {
  id: number;
  productName: string;
  priuce: number;
  quantity: number;
  pictureUrl: string;
  brrand: string;
  type: string;
}

export class Basket implements IBasket {
  id: uuidv4();
  items: IBasketItem[];
}
