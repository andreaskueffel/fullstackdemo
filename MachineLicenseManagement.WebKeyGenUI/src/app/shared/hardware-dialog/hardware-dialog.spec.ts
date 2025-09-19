import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HardwareDialog } from './hardware-dialog';

describe('HardwareDialog', () => {
  let component: HardwareDialog;
  let fixture: ComponentFixture<HardwareDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HardwareDialog]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HardwareDialog);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
