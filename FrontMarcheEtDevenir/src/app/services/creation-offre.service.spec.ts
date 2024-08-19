import { TestBed } from '@angular/core/testing';

import { CreationOffreService } from './creation-offre.service';

describe('CreationOffreService', () => {
  let service: CreationOffreService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CreationOffreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
