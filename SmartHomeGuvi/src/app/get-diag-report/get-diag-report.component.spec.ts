import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetDiagReportComponent } from './get-diag-report.component';

describe('GetDiagReportComponent', () => {
  let component: GetDiagReportComponent;
  let fixture: ComponentFixture<GetDiagReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetDiagReportComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetDiagReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
