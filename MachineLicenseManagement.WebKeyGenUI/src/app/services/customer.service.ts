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

  //read all customers
  customerGetAll(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.apiUrl);
  }

  //read one
  customerGetById(id: number): Observable<Customer> {
    return this.http.get<Customer>(`${this.apiUrl}/${id}`);
  }

  //create a new customer
  customerCreate(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.apiUrl, customer);
  }

  //update
  customerUpdate(customer: Customer): Observable<Customer> {
    return this.http.put<Customer>(
      `${this.apiUrl}/${customer.id}`,
      customer
    );
  }
  //delete
  customerDelete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
