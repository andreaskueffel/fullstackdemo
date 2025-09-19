import { Routes } from '@angular/router';
import { CustomerList } from './pages/customer-list/customer-list';
import { LicenseList } from './pages/license-list/license-list';

export const routes: Routes = [
    {path: '', redirectTo: 'licenses', pathMatch: 'full'},
    {path: 'licenses', component: LicenseList},
{path: 'customers', component: CustomerList},
];
