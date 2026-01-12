import { Routes } from '@angular/router';
import { CustomerList } from './pages/customer-list/customer-list';
import { CustomerForm } from './pages/customer-form/customer-form';
import { LicenseList } from './pages/license-list/license-list';

export const routes: Routes = [
  { path: '', redirectTo: 'licenses', pathMatch: 'full' },
  { path: 'licenses', component: LicenseList },
  // { path: 'licenses/new', component: LicenseCreate },
  { path: 'customers', component: CustomerList },
  { path: 'customers/new', component: CustomerForm },
  { path: 'customers/edit/:id', component: CustomerForm },
];
