import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GlobalAutomationComponent } from './global-automation.component';

describe('GlobalAutomationComponent', () => {
  let component: GlobalAutomationComponent;
  let fixture: ComponentFixture<GlobalAutomationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GlobalAutomationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GlobalAutomationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
