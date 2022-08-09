import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnnualSalaryInputComponent } from './annual-salary-input.component';

describe('AnnualSalaryInputComponent', () => {
  let component: AnnualSalaryInputComponent;
  let fixture: ComponentFixture<AnnualSalaryInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AnnualSalaryInputComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AnnualSalaryInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
