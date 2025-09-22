import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LicenseService } from '../../generated/api-client';

@Component({
  selector: 'app-license-list',
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './license-list.html',
  styleUrl: './license-list.scss'
})


export class LicenseList {
  licenses: any[] = [];
  constructor(private api: LicenseService) {
    api.licenseGetAll().subscribe(data => {
      console.log("received licenses", data);
      this.licenses = data;

    });

  }
}
