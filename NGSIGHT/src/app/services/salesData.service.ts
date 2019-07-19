import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SalesDataService {
  apiUrl: string = environment.apiUrl + 'orders/';

  constructor(private http: HttpClient) { }

  getOrders(pageIndex: number, pageSize: number) {
    return this.http.get(this.apiUrl + pageIndex + '/' + pageSize);
            // .pipe(map((res: Response) => res.json()))
  }

  getOrdersByCustomer(customersNumber: number) {
    return this.http.get(this.apiUrl + 'bycustomer/' + customersNumber);
            // .pipe(map((res: Response) => res.json()));
  }

  getOrdersByState() {
    return this.http.get(this.apiUrl + 'byState');
            // .pipe(map((res: Response) => res.json()));
  }


}
