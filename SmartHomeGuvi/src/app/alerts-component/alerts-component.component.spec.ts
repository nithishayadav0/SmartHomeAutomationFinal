import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlertsComponentComponent } from './alerts-component.component';

describe('AlertsComponentComponent', () => {
  let component: AlertsComponentComponent;
  let fixture: ComponentFixture<AlertsComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AlertsComponentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AlertsComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
