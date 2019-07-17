import { Order } from './../../shared/order';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-section-orders',
  templateUrl: './section-orders.component.html',
  styleUrls: ['./section-orders.component.css']
})
export class SectionOrdersComponent implements OnInit {
  orders: Order[] = [
    {id: 1, customer: {id: 1, name: 'Main st Bakery', state: 'CO', email: 'mainBakery@hgd.com'},
    total: 243, placed: new Date(2017, 8, 15), fulfilled: new Date(2017, 9, 13)},
    {id: 2, customer: {id: 2, name: 'Main st Bakery', state: 'CO', email: 'mainBakery@hgd.com'},
    total: 243, placed: new Date(2017, 8, 15), fulfilled: new Date(2017, 9, 13)},
  ];
  constructor() { }

  ngOnInit() {
  }

}
