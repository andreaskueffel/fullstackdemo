import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule, ActivatedRoute } from '@angular/router';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-customer-form',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './customer-form.html',
  styleUrl: './customer-form.scss'
})
export class CustomerForm {
  customer = {
    id: 0,
    name: '',
    address: '',
    zip: '',
    city: '',
    country: '',
    comment: ''
  };

  errors: any = {};
  customerId: number | null = null;
  isEditMode = false;
  isLoading = false;

  constructor(
    private customerService: CustomerService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.customerId = +params['id'];
        this.isEditMode = true;
        this.loadCustomer();
      }
    });
  }

  loadCustomer() {
    if (!this.customerId) return;
    this.isLoading = true;
    this.customerService.customerGetById(this.customerId).subscribe({
      next: (data) => {
        this.customer = data;
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error loading customer:', error);
        alert('Kunde konnte nicht geladen werden');
        this.router.navigate(['/customers']);
      }
    });
  }


  validateForm(): boolean {
    this.errors = {};
    if (!this.customer.name || !this.customer.name.trim()) {
      this.errors.name = 'Name ist erforderlich';
    }

    if (!this.customer.address || !this.customer.address.trim()) {
      this.errors.address = 'Adresse ist erforderlich';
    }

    if (!this.customer.zip || !this.customer.zip.trim()) {
      this.errors.zip = 'PLZ ist erforderlich';
    }
    else if (this.customer.zip && !/^\d{5}$/.test(this.customer.zip)) {
      this.errors.zip = 'PLZ muss 5 Ziffern haben';
    }

    if (!this.customer.city || !this.customer.city.trim()) {
      this.errors.city = 'Stadt ist erforderlich';
    }

    if (!this.customer.country || !this.customer.country.trim()) {
      this.errors.country = 'Land ist erforderlich';
    }

    return Object.keys(this.errors).length === 0;

  }

  onSubmit() {
    if (!this.validateForm()) {
      return;
    }
    if (this.isEditMode) {
      this.customerService.customerUpdate(this.customer).subscribe({
        next: (response) => {
          console.log('Customer updated:', response);
          alert('Kunde erfolgreich aktualisiert!');
          this.router.navigate(['/customers']);
        },
        error: (error) => {
          console.error('Error:', error);
          alert('Fehler beim Aktualisieren des Kunden');
        }
      });
    } else {
      this.customerService.customerCreate(this.customer).subscribe({
        next: (response) => {
          console.log('Customer created:', response);
          alert('Kunde erfolgreich erstellt!');
          this.router.navigate(['/customers']);
        },
        error: (error) => {
          console.error('Error:', error);
          alert('Fehler beim Erstellen des Kunden');
        }
      });
    }
  }
}
