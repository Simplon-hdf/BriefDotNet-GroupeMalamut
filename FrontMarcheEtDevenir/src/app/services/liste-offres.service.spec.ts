import { TestBed } from '@angular/core/testing';

import { ListeOffresService } from './liste-offres.service';

describe('ListeOffresService', () => {
  let service: ListeOffresService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ListeOffresService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
