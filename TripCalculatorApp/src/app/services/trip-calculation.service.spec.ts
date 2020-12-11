import { TestBed } from '@angular/core/testing';

import { TripCalculationService } from './trip-calculation.service';

describe('TripCalculationService', () => {
  let service: TripCalculationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TripCalculationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
