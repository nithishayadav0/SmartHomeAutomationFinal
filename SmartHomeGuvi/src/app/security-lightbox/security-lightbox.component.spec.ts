import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecurityLightboxComponent } from './security-lightbox.component';

describe('SecurityLightboxComponent', () => {
  let component: SecurityLightboxComponent;
  let fixture: ComponentFixture<SecurityLightboxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SecurityLightboxComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SecurityLightboxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
