import { Component, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Router } from '@angular/router';
import { CustomerService, Customer } from '../../services/customer.service';
import { ComponentsAngularModule } from "@dvs-design-system/components-angular";

@Component({
  selector: 'app-customer-list',
  imports: [CommonModule, RouterModule, ComponentsAngularModule],
  standalone: true,
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  templateUrl: './customer-list.html',
  styleUrl: './customer-list.scss'
})
export class CustomerList {
  customers: Customer[] = [];
  isLoading = true;

  constructor(
    private customerService: CustomerService,
    private router: Router
  ) {
    this.loadCustomers();
  }


  loadCustomers() {
    this.isLoading = true;

    this.customerService.customerGetAll().subscribe({
      next: (data) => {
        console.log('received customers', data);
        this.customers = data;
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error loading customers:', error);
        this.isLoading = false;
      }
    });
  }

  editCustomer(id: number) {
    this.router.navigate(['/customers/edit', id]);
  }

  deleteCustomer(id: number) {
    if (!confirm('Möchten Sie diesen Kunden wirklich löschen?')) {
      return;
    }

    this.customerService.customerDelete(id).subscribe({
      next: () => {
        console.log('Customer deleted');
        alert('Kunde erfolgreich gelöscht!');
        this.loadCustomers();
      },
      error: (error) => {
        console.error('Error deleting customer:', error);
        alert('Fehler beim Löschen des Kunden');
      }
    });
  }
}
