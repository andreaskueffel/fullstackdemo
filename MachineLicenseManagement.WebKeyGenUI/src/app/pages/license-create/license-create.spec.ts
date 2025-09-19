import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LicenseCreate } from './license-create';

describe('LicenseCreate', () => {
  let component: LicenseCreate;
  let fixture: ComponentFixture<LicenseCreate>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LicenseCreate]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LicenseCreate);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
