import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TechRoomsComponent } from './tech-rooms.component';

describe('TechRoomsComponent', () => {
  let component: TechRoomsComponent;
  let fixture: ComponentFixture<TechRoomsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TechRoomsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TechRoomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
