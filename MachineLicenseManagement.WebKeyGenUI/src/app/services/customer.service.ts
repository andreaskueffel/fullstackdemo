import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Customer {
  id: number;
  name: string;
  address: string;
  zip: string;
  city: string;
  country: string;
  comment: string;
}

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiUrl = 'http://localhost:5010/webkeygen/api/Customer';

  constructor(private http: HttpClient) { }

  customerGetAll(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.apiUrl);
  }

  customerCreate(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.apiUrl, customer);
  }
}
