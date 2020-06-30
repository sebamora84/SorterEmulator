import { TestBed } from '@angular/core/testing';

import { PhysicsService } from './physics.service';

describe('PhysicsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PhysicsService = TestBed.get(PhysicsService);
    expect(service).toBeTruthy();
  });
});
