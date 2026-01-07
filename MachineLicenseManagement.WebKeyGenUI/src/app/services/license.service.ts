import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface License {
  id: number;
  customerId: number;
  licenseKey: string;
  createdAt: string;
  createdByUserId: number;
  licensedProductId: number;
  machineId: string;
  information: string;
  hardwareInformationString: string;
  selectedHardwareId: string;
}

@Injectable({
  providedIn: 'root'
})
export class LicenseService {
  private apiUrl = 'http://localhost:5010/webkeygen/api/License';

  constructor(private http: HttpClient) { }

  licenseGetAll(): Observable<License[]> {
    return this.http.get<License[]>(this.apiUrl);
  }
}
