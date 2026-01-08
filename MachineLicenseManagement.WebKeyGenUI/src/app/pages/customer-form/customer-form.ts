import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
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

  constructor(
    private customerService: CustomerService,
    private router: Router
  ) { }

  onSubmit() {
    if (!this.customer.name || this.customer.name.trim() === '') {
      alert('Bitte geben Sie einen Namen ein!');
      return;
    }
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
