import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SendMaintenanceComponent } from './send-maintenance.component';

describe('SendMaintenanceComponent', () => {
  let component: SendMaintenanceComponent;
  let fixture: ComponentFixture<SendMaintenanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SendMaintenanceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SendMaintenanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
