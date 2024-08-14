import { TestBed } from '@angular/core/testing';

import { FormulaireInscriptionServiceService } from './formulaire-inscription-service';

describe('FormulaireInscriptionServiceService', () => {
  let service: FormulaireInscriptionServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FormulaireInscriptionServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
