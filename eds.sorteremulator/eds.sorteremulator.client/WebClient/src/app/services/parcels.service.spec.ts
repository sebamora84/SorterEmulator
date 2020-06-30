import { TestBed } from '@angular/core/testing';

import { ParcelsService } from './parcels.service';

describe('ParcelsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ParcelsService = TestBed.get(ParcelsService);
    expect(service).toBeTruthy();
  });
});
