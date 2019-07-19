import { SalesDataService } from './../../services/salesData.service';
import { Order } from './../../shared/order';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-section-orders',
  templateUrl: './section-orders.component.html',
  styleUrls: ['./section-orders.component.css']
})

export class SectionOrdersComponent implements OnInit {
  orders: any;
  total = 0;
  page = 1;
  limit = 10;
  loading = false;

  constructor(private salesSrvc: SalesDataService) { }

  ngOnInit() {
    this.getOrders();
  }

  getOrders() {
    this.salesSrvc.getOrders(this.page, this.limit).subscribe( res => {
      console.log('Result from getOrders: ', res);
      this.orders = res['page']['data'];
      this.total = res['page'].total;
      this.loading = false;
    });
  }

  goToPrevious() {
    this.page !== 1 ? this.page-- : this.page = 1;
    this.getOrders();
  }

  goToNext() {
    this.page++;
    this.getOrders();
  }

  goToPage(n: number): void {
    this.page = n;
    this.getOrders();
  }

}











/*
orders: Order[] = [
  {id: 1, customer: {id: 1, name: 'Main st Bakery', state: 'CO', email: 'mainBakery@hgd.com'},
  total: 243, placed: new Date(2017, 8, 15), fulfilled: new Date(2017, 9, 13)},
  {id: 2, customer: {id: 2, name: 'Main st Bakery', state: 'CO', email: 'mainBakery@hgd.com'},
  total: 243, placed: new Date(2017, 8, 15), fulfilled: new Date(2017, 9, 13)},
];


*/
