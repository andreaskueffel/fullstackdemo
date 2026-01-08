import { Component } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-customer-list',
  imports: [
    CommonModule, RouterModule
  ],
  templateUrl: './customer-list.html',
  styleUrl: './customer-list.scss'
})
export class CustomerList {
  customers: any[] = [];
  isLoading = true;

  constructor(private api: CustomerService) {

    this.api.customerGetAll().subscribe(data => {
      console.log("received customers", data);
      this.customers = data;
      this.isLoading = false;
    });
  }
}
