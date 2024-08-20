import { TestBed } from '@angular/core/testing';

import { RecuperationRandonneeService } from './recuperation-randonnee.service';

describe('RecuperationRandonneeService', () => {
  let service: RecuperationRandonneeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RecuperationRandonneeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
