import { TestBed } from '@angular/core/testing';

import { AnnualSalaryService } from './annual-salary.service';

describe('AnnualSalaryServiceService', () => {
  let service: AnnualSalaryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AnnualSalaryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
