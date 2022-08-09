import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnnualSalaryOutputComponent } from './annual-salary-output.component';

describe('AnnualSalaryOutputComponent', () => {
  let component: AnnualSalaryOutputComponent;
  let fixture: ComponentFixture<AnnualSalaryOutputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AnnualSalaryOutputComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AnnualSalaryOutputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
