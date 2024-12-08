import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TechHomeComponent } from './tech-home.component';

describe('TechHomeComponent', () => {
  let component: TechHomeComponent;
  let fixture: ComponentFixture<TechHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TechHomeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TechHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
