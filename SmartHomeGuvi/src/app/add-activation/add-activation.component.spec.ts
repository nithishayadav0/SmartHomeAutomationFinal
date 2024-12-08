import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddActivationComponent } from './add-activation.component';

describe('AddActivationComponent', () => {
  let component: AddActivationComponent;
  let fixture: ComponentFixture<AddActivationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddActivationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddActivationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
