import { Component } from '@angular/core';
import { CustomerService } from '../../generated/api-client';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-customer-list',
  imports: [
    CommonModule
  ],
  templateUrl: './customer-list.html',
  styleUrl: './customer-list.scss'
})
export class CustomerList {
  customers: any[] = [];

constructor(private api: CustomerService){

  this.api.customerGetAll().subscribe(data => {
    console.log("received customers", data);
    this.customers = data;
  });
}
}
